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
                NationalityCountryId = request.NationalityCountryId,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _personRepository.AddAsync(person, false);

            var personTranslation = new PersonTranslation
            {
                PersonId = person.Id,
                LanguageId = request.PreferredLanguageId,
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            await _personTranslationRepository.AddAsync(personTranslation, true);

            return _mapper.Map<PersonDto>(person);
        }
    }
}
