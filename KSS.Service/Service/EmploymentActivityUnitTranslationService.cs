using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class EmploymentActivityUnitTranslationService : BaseService<EmploymentActivityUnitTranslation, EmploymentActivityUnitTranslationDto, EmploymentActivityUnitTranslationDto, EmploymentActivityUnitTranslationDto>, IEmploymentActivityUnitTranslationService
    {
        public EmploymentActivityUnitTranslationService(IMapper mapper, IEmploymentActivityUnitTranslationRepository repository) : base(mapper, repository) { }
    }
}
