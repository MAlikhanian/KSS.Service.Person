using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class PersonService : BaseService<Person, PersonDto, PersonDto, PersonDto>, IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IPersonTranslationRepository _personTranslationRepository;

        public PersonService(IMapper mapper, IPersonRepository repository, IPersonTranslationRepository personTranslationRepository) : base(mapper, repository)
        {
            _personRepository = repository;
            _personTranslationRepository = personTranslationRepository;
        }

        public async Task<PersonDto> CreatePersonWithTranslationAsync(CreatePersonWithTranslationDto request)
        {
            var person = new Person
            {
                Id = Guid.CreateVersion7(),
                SexId = request.SexId,
                PreferredLanguageId = request.PreferredLanguageId,
                NationalId = request.NationalId ?? Guid.NewGuid().ToString("N")[..20],
                DateOfBirth = request.DateOfBirth ?? new DateTime(1990, 1, 1),
                BirthCountryId = request.BirthCountryId,
                BirthRegionId = request.BirthRegionId,
                BirthCityId = request.BirthCityId,
                BirthCertificateNumber = request.BirthCertificateNumber,
                BirthCertificateSeriesNumber = request.BirthCertificateSeriesNumber,
                BirthCertificateSeriesLetterId = request.BirthCertificateSeriesLetterId,
                BirthCertificateSerial = request.BirthCertificateSerial,
                BirthCertificateIssueCountryId = request.BirthCertificateIssueCountryId,
                BirthCertificateIssueRegionId = request.BirthCertificateIssueRegionId,
                BirthCertificateIssueCityId = request.BirthCertificateIssueCityId,
                MaritalStatusId = request.MaritalStatusId,
                ReligionId = request.ReligionId,
                PassportNumber = request.PassportNumber,
                MilitaryServiceStatusId = request.MilitaryServiceStatusId,
                MilitaryServiceLocationId = request.MilitaryServiceLocationId,
                InsuranceTypeId = request.InsuranceTypeId,
                InsuranceNumber = request.InsuranceNumber,
                IsActive = request.IsActive,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            // Save person without committing yet
            await _personRepository.AddAsync(person, false);

            // Create each translation (FA, EN) — save all without committing
            var validTranslations = request.Translations
                .Where(tr => !string.IsNullOrWhiteSpace(tr.FirstName) || !string.IsNullOrWhiteSpace(tr.LastName))
                .ToList();

            for (var i = 0; i < validTranslations.Count; i++)
            {
                var tr = validTranslations[i];
                var translation = new PersonTranslation
                {
                    PersonId = person.Id,
                    LanguageId = tr.LanguageId,
                    FirstName = tr.FirstName,
                    LastName = tr.LastName,
                    FatherName = tr.FatherName
                };

                // Commit on the last translation
                var isLast = i == validTranslations.Count - 1;
                await _personTranslationRepository.AddAsync(translation, isLast);
            }

            // If no translations were provided, still commit the person
            if (validTranslations.Count == 0)
            {
                await _personRepository.SaveChangesAsync();
            }

            return _mapper.Map<PersonDto>(person);
        }

        /// <summary>
        /// Upsert translations for an existing person.
        /// Determines add vs update per language (like company pattern).
        /// </summary>
        public async Task UpsertTranslationsAsync(UpsertPersonTranslationsDto dto)
        {
            var existing = _personTranslationRepository.ToList(
                t => t.PersonId == dto.PersonId);
            var existingByLang = existing.ToDictionary(t => t.LanguageId);

            foreach (var tr in dto.Translations)
            {
                if (string.IsNullOrWhiteSpace(tr.FirstName) && string.IsNullOrWhiteSpace(tr.LastName))
                    continue;

                if (existingByLang.TryGetValue(tr.LanguageId, out var existingTranslation))
                {
                    // Update tracked entity properties — no need to call Update(),
                    // EF change tracker already detects the modifications
                    existingTranslation.FirstName = tr.FirstName;
                    existingTranslation.LastName = tr.LastName;
                    existingTranslation.FatherName = tr.FatherName;
                }
                else
                {
                    var entity = new PersonTranslation
                    {
                        PersonId = dto.PersonId,
                        LanguageId = tr.LanguageId,
                        FirstName = tr.FirstName,
                        LastName = tr.LastName,
                        FatherName = tr.FatherName
                    };
                    await _personTranslationRepository.AddAsync(entity, false);
                }
            }

            // Save all changes in one batch
            await _personTranslationRepository.SaveChangesAsync();
        }
    }
}
