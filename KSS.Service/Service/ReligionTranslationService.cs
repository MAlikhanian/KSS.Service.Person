using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class ReligionTranslationService : BaseService<ReligionTranslation, ReligionTranslationDto, ReligionTranslationDto, ReligionTranslationDto>, IReligionTranslationService
    {
        public ReligionTranslationService(IMapper mapper, IReligionTranslationRepository repository) : base(mapper, repository) { }
    }
}
