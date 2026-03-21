using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class InsuranceTypeTranslationService : BaseService<InsuranceTypeTranslation, InsuranceTypeTranslationDto, InsuranceTypeTranslationDto, InsuranceTypeTranslationDto>, IInsuranceTypeTranslationService
    {
        public InsuranceTypeTranslationService(IMapper mapper, IInsuranceTypeTranslationRepository repository) : base(mapper, repository) { }
    }
}
