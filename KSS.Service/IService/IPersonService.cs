using KSS.Dto;
using KSS.Entity;

namespace KSS.Service.IService
{
    public interface IPersonService : IBaseService<Person, PersonDto, PersonDto, PersonDto>
    {
        Task<PersonDto> CreatePersonWithTranslationAsync(CreatePersonWithTranslationDto request);
        Task UpsertTranslationsAsync(UpsertTranslationsDto dto);

        /// <summary>
        /// Returns ALL persons with minimal info only (Id, NationalId,
        /// translation names) — bypasses the access filter. Used by features
        /// like the access-grant dropdown that need to pick from every person.
        /// Profile details remain access-protected via the regular endpoints.
        /// </summary>
        Task<IEnumerable<PersonDirectoryDto>> ListDirectoryAsync();

        /// <summary>
        /// Bypass-access list of all employment rows (minimal shape) for
        /// cross-service reporting. Like ListDirectoryAsync, skips the per-caller
        /// visibility filter.
        /// </summary>
        Task<IEnumerable<EmploymentDirectoryDto>> ListEmploymentsAsync();

        /// <summary>
        /// Bypass-access per-person demographics (sex, DOB) for cross-service
        /// reporting. Like ListDirectoryAsync, skips the per-caller filter.
        /// </summary>
        Task<IEnumerable<PersonDemographicsDto>> ListDemographicsAsync();

        /// <summary>
        /// Returns the caller's own minimal person info (Id, NationalId,
        /// translations) based on the personId claim in the JWT.
        /// No section permission is required — every authenticated user can
        /// see themselves. Returns null if the JWT has no personId claim or
        /// the referenced person record is missing.
        /// </summary>
        Task<PersonDirectoryDto?> GetSelfAsync();

        /// <summary>
        /// Distinct list of UserIds that appear as Person.CreatedBy across the
        /// ENTIRE table — bypasses the per-user access filter (which the
        /// overridden ToListAsync applies). Powers the dashboard Highlights
        /// panel's "With Active User & Created Persons" row.
        /// </summary>
        Task<List<Guid>> GetDistinctCreatorIdsAsync();

        /// <summary>
        /// Resolve display names for a SPECIFIC set of person ids in one call.
        /// Bypasses the access filter (like Directory) and exposes only the
        /// name + nationalId. Used by other services (e.g. the Company
        /// stakeholder view) to resolve related-party / board-representative
        /// names without pulling the full directory.
        /// </summary>
        Task<List<PersonNameDto>> GetNamesByIdsAsync(IReadOnlyCollection<Guid> ids, short languageId = 12);
    }
}
