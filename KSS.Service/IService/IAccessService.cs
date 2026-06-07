using KSS.Dto;
using KSS.Entity;

namespace KSS.Service.IService
{
    public interface IAccessService : IBaseService<Access, AccessDto, AccessAddDto, AccessDto>
    {
        /// <summary>
        /// Returns the caller's per-section levels for the given person.
        /// If the caller IS the owner, returns {2,2,2}. Otherwise, sections
        /// with no row default to 0 (None).
        /// </summary>
        Task<AccessLevelsDto> GetLevelsAsync(Guid personId, Guid callerPersonId);

        /// <summary>
        /// Owner-only. Replaces all access rows for (PersonId, GrantedToPersonId)
        /// with one row per section whose Level &gt; 0.
        /// </summary>
        Task UpsertGrantAsync(AccessGrantDto dto, Guid callerPersonId);

        /// <summary>
        /// Owner-only. Deletes all rows for the (PersonId, GrantedToPersonId) pair.
        /// </summary>
        Task RevokeByPairAsync(Guid personId, Guid grantedToPersonId, Guid callerPersonId);

        /// <summary>
        /// Lists every grantee an owner has granted access to, with all three
        /// section levels rolled up. One entry per grantee.
        /// </summary>
        Task<List<AccessGrantSummaryDto>> ListGrantsByOwnerAsync(Guid personId);
    }
}
