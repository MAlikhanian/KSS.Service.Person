using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class PersonTranslationService : BaseService<PersonTranslation, PersonTranslationDto, PersonTranslationDto, PersonTranslationDto>, IPersonTranslationService
    {
        public PersonTranslationService(IMapper mapper, IPersonTranslationRepository repository) : base(mapper, repository) { }
    }
}
