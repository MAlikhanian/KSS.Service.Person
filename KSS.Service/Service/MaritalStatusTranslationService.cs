using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class MaritalStatusTranslationService : BaseService<MaritalStatusTranslation, MaritalStatusTranslationDto, MaritalStatusTranslationDto, MaritalStatusTranslationDto>, IMaritalStatusTranslationService
    {
        public MaritalStatusTranslationService(IMapper mapper, IMaritalStatusTranslationRepository repository) : base(mapper, repository) { }
    }
}
