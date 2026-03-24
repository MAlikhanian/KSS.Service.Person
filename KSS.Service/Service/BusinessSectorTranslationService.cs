using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class BusinessSectorTranslationService : BaseService<BusinessSectorTranslation, BusinessSectorTranslationDto, BusinessSectorTranslationDto, BusinessSectorTranslationDto>, IBusinessSectorTranslationService
    {
        public BusinessSectorTranslationService(IMapper mapper, IBusinessSectorTranslationRepository repository) : base(mapper, repository) { }
    }
}
