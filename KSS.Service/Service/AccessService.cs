using System.Security.Claims;
using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Helper;
using KSS.Repository.IRepository;
using KSS.Service.IService;
using Microsoft.AspNetCore.Http;

namespace KSS.Service.Service
{
    public class AccessService : BaseService<Access, AccessDto, AccessAddDto, AccessDto>, IAccessService
    {
        private readonly IAccessRepository _repository;
        private readonly IRoleAccessRepository _roleAccessRepository;
        private readonly IHttpContextAccessor? _httpContextAccessor;

        public AccessService(
            IMapper mapper,
            IAccessRepository repository,
            IRoleAccessRepository roleAccessRepository,
            IHttpContextAccessor? httpContextAccessor = null) : base(mapper, repository)
        {
            _repository = repository;
            _roleAccessRepository = roleAccessRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        // Reads "roleId" claims from the JWT — used to evaluate RoleAccess rows.
        private List<Guid> GetCallerRoleIds()
        {
            var user = _httpContextAccessor?.HttpContext?.User;
            if (user?.Identity?.IsAuthenticated != true) return new List<Guid>();
            return user.FindAll("roleId")
                .Select(c => Guid.TryParse(c.Value, out var id) ? id : Guid.Empty)
                .Where(id => id != Guid.Empty)
                .Distinct()
                .ToList();
        }

        public async Task<AccessLevelsDto> GetLevelsAsync(Guid personId, Guid callerPersonId)
        {
            // Owner always has Edit on every section of their own profile.
            if (personId == callerPersonId)
                return new AccessLevelsDto { Information = 2, Assets = 2, Access = 2, Security = 2 };

            var rows = await _repository.ToListAsync(
                pa => pa.PersonId == personId && pa.GrantedToPersonId == callerPersonId);

            var dto = new AccessLevelsDto();
            foreach (var row in rows)
            {
                switch (row.SectionId)
                {
                    case AccessSectionId.Information: dto.Information = row.Level; break;
                    case AccessSectionId.Assets:      dto.Assets      = row.Level; break;
                    case AccessSectionId.Access:      dto.Access      = row.Level; break;
                    case AccessSectionId.Security:    dto.Security    = row.Level; break;
                }
            }

            // Layer role-based grants on top: a RoleAccess row matches if its
            // GrantedToRoleId is in the caller's roleIds AND (PersonId == personId
            // OR PersonId IS NULL). Role grants raise the level — never lower it.
            var roleIds = GetCallerRoleIds();
            if (roleIds.Count > 0)
            {
                var roleRows = await _roleAccessRepository.ToListAsync(
                    ra => roleIds.Contains(ra.GrantedToRoleId)
                       && (ra.PersonId == personId || ra.PersonId == null));

                foreach (var row in roleRows)
                {
                    switch (row.SectionId)
                    {
                        case AccessSectionId.Information: dto.Information = Math.Max(dto.Information, row.Level); break;
                        case AccessSectionId.Assets:      dto.Assets      = Math.Max(dto.Assets,      row.Level); break;
                        case AccessSectionId.Access:      dto.Access      = Math.Max(dto.Access,      row.Level); break;
                        case AccessSectionId.Security:    dto.Security    = Math.Max(dto.Security,    row.Level); break;
                    }
                }
            }

            return dto;
        }

        public async Task UpsertGrantAsync(AccessGrantDto dto, Guid callerPersonId)
        {
            // Authorization: caller must have Edit (Level 2) on the Access
            // section of this person. Owner gets that automatically (see
            // GetLevelsAsync); admins get it via global RoleAccess.
            var levels = await GetLevelsAsync(dto.PersonId, callerPersonId);
            if (levels.Access < 2)
                throw new BusinessRuleException("شما اجازه اعطای دسترسی برای این فرد را ندارید");

            if (dto.GrantedToPersonId == Guid.Empty)
                throw new BusinessRuleException("شخص هدف الزامی است");

            // Disallow granting access to yourself (already implicit owner).
            if (dto.GrantedToPersonId == dto.PersonId)
                throw new BusinessRuleException("نمی‌توانید به خودتان دسترسی اعطا کنید");

            // Validate each level is 0/1/2.
            if (!IsValidLevel(dto.InformationLevel) ||
                !IsValidLevel(dto.AssetsLevel) ||
                !IsValidLevel(dto.AccessLevel) ||
                !IsValidLevel(dto.SecurityLevel))
                throw new BusinessRuleException("سطح دسترسی نامعتبر است");

            // Replace all rows for this (PersonId, GrantedToPersonId) pair atomically:
            // delete existing → insert one row per non-zero section.
            var existing = await _repository.ToListAsync(
                pa => pa.PersonId == dto.PersonId && pa.GrantedToPersonId == dto.GrantedToPersonId);

            foreach (var row in existing)
                _repository.Remove(row, false);

            void AddIfPositive(byte sectionId, int level)
            {
                if (level <= 0) return;
                var entity = new Access
                {
                    PersonId = dto.PersonId,
                    GrantedToPersonId = dto.GrantedToPersonId,
                    SectionId = sectionId,
                    Level = level,
                    // Id, CreatedAt, UpdatedAt, CreatedBy populated by ApplyEntityDefaults.
                };
                _repository.AddUnawaited(entity, false);
            }

            AddIfPositive(AccessSectionId.Information, dto.InformationLevel);
            AddIfPositive(AccessSectionId.Assets,      dto.AssetsLevel);
            AddIfPositive(AccessSectionId.Access,      dto.AccessLevel);
            AddIfPositive(AccessSectionId.Security,    dto.SecurityLevel);

            await _repository.SaveChangesAsync();
        }

        public async Task RevokeByPairAsync(Guid personId, Guid grantedToPersonId, Guid callerPersonId)
        {
            // Same authorization rule as UpsertGrantAsync — owner OR Access-Edit.
            var levels = await GetLevelsAsync(personId, callerPersonId);
            if (levels.Access < 2)
                throw new BusinessRuleException("شما اجازه حذف دسترسی برای این فرد را ندارید");

            var rows = await _repository.ToListAsync(
                pa => pa.PersonId == personId && pa.GrantedToPersonId == grantedToPersonId);

            if (!rows.Any())
                throw new BusinessRuleException("دسترسی یافت نشد");

            foreach (var row in rows)
                _repository.Remove(row, false);

            await _repository.SaveChangesAsync();
        }

        public async Task<List<AccessGrantSummaryDto>> ListGrantsByOwnerAsync(Guid personId)
        {
            var rows = await _repository.ToListAsync(pa => pa.PersonId == personId);

            return rows
                .GroupBy(r => r.GrantedToPersonId)
                .Select(g =>
                {
                    var groupList = g.ToList();
                    var summary = new AccessGrantSummaryDto
                    {
                        PersonId = personId,
                        GrantedToPersonId = g.Key,
                        // Earliest CreatedAt = when the grant was first issued.
                        CreatedAt = groupList.Min(r => r.CreatedAt),
                        // Latest UpdatedAt across all 3 section rows; null if none have been updated.
                        UpdatedAt = groupList.Max(r => r.UpdatedAt),
                    };
                    foreach (var row in groupList)
                    {
                        switch (row.SectionId)
                        {
                            case AccessSectionId.Information: summary.InformationLevel = row.Level; break;
                            case AccessSectionId.Assets:      summary.AssetsLevel      = row.Level; break;
                            case AccessSectionId.Access:      summary.AccessLevel      = row.Level; break;
                            case AccessSectionId.Security:    summary.SecurityLevel    = row.Level; break;
                        }
                    }
                    return summary;
                })
                .ToList();
        }

        private static bool IsValidLevel(int level) => level >= 0 && level <= 2;
    }
}
