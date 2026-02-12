using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class SexTranslationService : BaseService<SexTranslation, SexTranslationDto, SexTranslationDto, SexTranslationDto>, ISexTranslationService
    {
        public SexTranslationService(IMapper mapper, ISexTranslationRepository repository) : base(mapper, repository) { }
    }
}
