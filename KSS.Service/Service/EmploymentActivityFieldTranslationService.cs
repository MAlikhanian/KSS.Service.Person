using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class EmploymentActivityFieldTranslationService : BaseService<EmploymentActivityFieldTranslation, EmploymentActivityFieldTranslationDto, EmploymentActivityFieldTranslationDto, EmploymentActivityFieldTranslationDto>, IEmploymentActivityFieldTranslationService
    {
        public EmploymentActivityFieldTranslationService(IMapper mapper, IEmploymentActivityFieldTranslationRepository repository) : base(mapper, repository) { }
    }
}
