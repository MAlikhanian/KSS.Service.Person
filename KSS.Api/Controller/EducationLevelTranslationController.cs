using KSS.Dto;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    public class EducationLevelTranslationController : BaseController<EducationLevelTranslation, EducationLevelTranslationDto, EducationLevelTranslationDto, EducationLevelTranslationDto>
    {
        public EducationLevelTranslationController(IEducationLevelTranslationService service) : base(service) { }
    }
}
