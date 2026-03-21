using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class MilitaryServiceLocationTranslationService : BaseService<MilitaryServiceLocationTranslation, MilitaryServiceLocationTranslationDto, MilitaryServiceLocationTranslationDto, MilitaryServiceLocationTranslationDto>, IMilitaryServiceLocationTranslationService
    {
        public MilitaryServiceLocationTranslationService(IMapper mapper, IMilitaryServiceLocationTranslationRepository repository) : base(mapper, repository) { }
    }
}
