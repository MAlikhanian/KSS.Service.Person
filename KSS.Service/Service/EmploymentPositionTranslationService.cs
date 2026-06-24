using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class EmploymentPositionTranslationService : BaseService<EmploymentPositionTranslation, EmploymentPositionTranslationDto, EmploymentPositionTranslationDto, EmploymentPositionTranslationDto>, IEmploymentPositionTranslationService
    {
        public EmploymentPositionTranslationService(IMapper mapper, IEmploymentPositionTranslationRepository repository) : base(mapper, repository) { }
    }
}
