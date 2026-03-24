using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class BusinessUnitTranslationService : BaseService<BusinessUnitTranslation, BusinessUnitTranslationDto, BusinessUnitTranslationDto, BusinessUnitTranslationDto>, IBusinessUnitTranslationService
    {
        public BusinessUnitTranslationService(IMapper mapper, IBusinessUnitTranslationRepository repository) : base(mapper, repository) { }
    }
}
