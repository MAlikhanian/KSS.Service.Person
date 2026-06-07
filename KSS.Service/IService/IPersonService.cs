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
    }
}
