using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Helper;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class RoleAccessService : BaseService<RoleAccess, RoleAccessDto, RoleAccessDto, RoleAccessDto>, IRoleAccessService
    {
        private readonly IRoleAccessRepository _repository;
        private readonly IAccessRepository _accessRepository;
        private readonly IAccessService _accessService;

        public RoleAccessService(
            IMapper mapper,
            IRoleAccessRepository repository,
            IAccessRepository accessRepository,
            IAccessService accessService) : base(mapper, repository)
        {
            _repository = repository;
            _accessRepository = accessRepository;
            _accessService = accessService;
        }

        public async Task<List<RoleAccessGrantSummaryDto>> ListGrantsByPersonAsync(Guid personId)
        {
            // Per-person rows for this person + all global rows (PersonId == NULL).
            var rows = await _repository.ToListAsync(
                ra => ra.PersonId == personId || ra.PersonId == null);

            return GroupRows(rows);
        }

        public async Task<List<RoleAccessGrantSummaryDto>> ListAllGrantsAsync()
        {
            var rows = await _repository.ToListAsync();
            return GroupRows(rows);
        }

        public async Task UpsertGrantAsync(RoleAccessGrantDto dto, Guid callerPersonId)
        {
            if (dto.GrantedToRoleId == Guid.Empty)
                throw new BusinessRuleException("نقش هدف الزامی است");

            if (!IsValidLevel(dto.InformationLevel) ||
                !IsValidLevel(dto.AssetsLevel) ||
                !IsValidLevel(dto.AccessLevel) ||
                !IsValidLevel(dto.SecurityLevel))
                throw new BusinessRuleException("سطح دسترسی نامعتبر است");

            // Global RoleAccess rows (PersonId IS NULL) define system-wide admin
            // visibility. They are infrastructure — managed only via versioned
            // migrations, never via the API. Upserts that delete-then-insert can
            // silently destroy these rows (e.g. saving with all levels = 0).
            if (dto.PersonId == Guid.Empty)
                throw new BusinessRuleException("GLOBAL_ROLE_GRANT_MODIFY_FORBIDDEN");

            // Authorization: caller must have Edit (Level 2) on the Access
            // section of this person. Owner passes automatically; admins pass
            // via global RoleAccess; per-person Access grants also count.
            var levels = await _accessService.GetLevelsAsync(dto.PersonId, callerPersonId);
            if (levels.Access < 2)
                throw new BusinessRuleException("شما اجازه اعطای دسترسی نقشی برای این فرد را ندارید");

            // Replace all rows for this (PersonId, GrantedToRoleId) pair.
            var existing = await _repository.ToListAsync(
                ra => ra.PersonId == dto.PersonId && ra.GrantedToRoleId == dto.GrantedToRoleId);

            foreach (var row in existing)
                _repository.Remove(row, false);

            void AddIfPositive(byte sectionId, int level)
            {
                if (level <= 0) return;
                var entity = new RoleAccess
                {
                    PersonId = dto.PersonId,
                    GrantedToRoleId = dto.GrantedToRoleId,
                    SectionId = sectionId,
                    Level = level,
                };
                _repository.AddUnawaited(entity, false);
            }

            AddIfPositive(AccessSectionId.Information, dto.InformationLevel);
            AddIfPositive(AccessSectionId.Assets,      dto.AssetsLevel);
            AddIfPositive(AccessSectionId.Access,      dto.AccessLevel);
            AddIfPositive(AccessSectionId.Security,    dto.SecurityLevel);

            await _repository.SaveChangesAsync();
        }

        public async Task RevokeByPairAsync(Guid? personId, Guid grantedToRoleId, Guid callerPersonId)
        {
            // Global RoleAccess rows are immutable infrastructure — protected
            // from accidental deletion. Manage via migrations only.
            if (personId is null)
                throw new BusinessRuleException("GLOBAL_ROLE_GRANT_DELETE_FORBIDDEN");

            if (personId.HasValue)
            {
                var levels = await _accessService.GetLevelsAsync(personId.Value, callerPersonId);
                if (levels.Access < 2)
                    throw new BusinessRuleException("شما اجازه حذف دسترسی نقشی این فرد را ندارید");
            }

            var rows = await _repository.ToListAsync(
                ra => ra.PersonId == personId && ra.GrantedToRoleId == grantedToRoleId);

            if (!rows.Any())
                throw new BusinessRuleException("دسترسی یافت نشد");

            foreach (var row in rows)
                _repository.Remove(row, false);

            await _repository.SaveChangesAsync();
        }

        private static List<RoleAccessGrantSummaryDto> GroupRows(IEnumerable<RoleAccess> rows)
        {
            return rows
                .GroupBy(r => new { r.PersonId, r.GrantedToRoleId })
                .Select(g =>
                {
                    var groupList = g.ToList();
                    var summary = new RoleAccessGrantSummaryDto
                    {
                        PersonId = g.Key.PersonId,
                        GrantedToRoleId = g.Key.GrantedToRoleId,
                        CreatedAt = groupList.Min(r => r.CreatedAt),
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
