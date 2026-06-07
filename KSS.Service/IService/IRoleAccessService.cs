using KSS.Dto;
using KSS.Entity;

namespace KSS.Service.IService
{
    public interface IRoleAccessService : IBaseService<RoleAccess, RoleAccessDto, RoleAccessDto, RoleAccessDto>
    {
        /// <summary>
        /// Lists per-person role grants for a single person, plus all global grants.
        /// One entry per (PersonId, GrantedToRoleId) pair — PersonId may be null for globals.
        /// </summary>
        Task<List<RoleAccessGrantSummaryDto>> ListGrantsByPersonAsync(Guid personId);

        /// <summary>
        /// Lists every role grant in the system, grouped by (PersonId, GrantedToRoleId).
        /// Used for the global admin view.
        /// </summary>
        Task<List<RoleAccessGrantSummaryDto>> ListAllGrantsAsync();

        /// <summary>
        /// Replaces all role-access rows for a (PersonId, GrantedToRoleId) pair
        /// with one row per section whose Level &gt; 0. PersonId == null means
        /// the grant applies to all persons (caller must be SuperAdmin to do this).
        /// </summary>
        Task UpsertGrantAsync(RoleAccessGrantDto dto, Guid callerPersonId);

        /// <summary>
        /// Deletes all rows for a (PersonId, GrantedToRoleId) pair. PersonId may
        /// be null to revoke a global grant.
        /// </summary>
        Task RevokeByPairAsync(Guid? personId, Guid grantedToRoleId, Guid callerPersonId);
    }
}
