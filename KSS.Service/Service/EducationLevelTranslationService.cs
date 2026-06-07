using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class EducationLevelTranslationService : BaseService<EducationLevelTranslation, EducationLevelTranslationDto, EducationLevelTranslationDto, EducationLevelTranslationDto>, IEducationLevelTranslationService
    {
        public EducationLevelTranslationService(IMapper mapper, IEducationLevelTranslationRepository repository) : base(mapper, repository) { }
    }
}
