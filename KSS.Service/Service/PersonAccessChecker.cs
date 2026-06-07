using System.Security.Claims;
using KSS.Helper;
using KSS.Repository.IRepository;
using KSS.Service.IService;
using Microsoft.AspNetCore.Http;

namespace KSS.Service.Service
{
    public class PersonAccessChecker : IPersonAccessChecker
    {
        private readonly IAccessRepository _accessRepository;
        private readonly IRoleAccessRepository _roleAccessRepository;
        private readonly IHttpContextAccessor? _httpContextAccessor;

        public PersonAccessChecker(
            IAccessRepository accessRepository,
            IRoleAccessRepository roleAccessRepository,
            IHttpContextAccessor? httpContextAccessor = null)
        {
            _accessRepository = accessRepository;
            _roleAccessRepository = roleAccessRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> CanSeeAsync(Guid personId)
        {
            var callerId = GetCallerPersonId();
            if (callerId == null) return false;

            // Rule 1 — self.
            if (personId == callerId.Value) return true;

            var roleIds = GetCallerRoleIds();

            // Rule 2 — global RoleAccess (PersonId == NULL) for any of caller's roles.
            if (roleIds.Count > 0)
            {
                var globalCount = await _roleAccessRepository.CountAsync(
                    ra => ra.PersonId == null && roleIds.Contains(ra.GrantedToRoleId));
                if (globalCount > 0) return true;
            }

            // Rule 3 — per-person Access row linking caller → target.
            var personAccessCount = await _accessRepository.CountAsync(
                a => a.PersonId == personId && a.GrantedToPersonId == callerId.Value);
            if (personAccessCount > 0) return true;

            // Rule 4 — per-person RoleAccess scoped to target for any of caller's roles.
            if (roleIds.Count > 0)
            {
                var roleScopedCount = await _roleAccessRepository.CountAsync(
                    ra => ra.PersonId == personId && roleIds.Contains(ra.GrantedToRoleId));
                if (roleScopedCount > 0) return true;
            }

            return false;
        }

        public async Task EnsureCanSeeAsync(Guid personId)
        {
            if (!await CanSeeAsync(personId))
                throw new BusinessRuleException("شما اجازه مشاهده این شخص را ندارید");
        }

        private Guid? GetCallerPersonId()
        {
            var user = _httpContextAccessor?.HttpContext?.User;
            if (user?.Identity?.IsAuthenticated != true) return null;
            var raw = user.FindFirstValue("personId") ?? user.FindFirstValue(ClaimTypes.NameIdentifier);
            return Guid.TryParse(raw, out var id) ? id : null;
        }

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
    }
}
