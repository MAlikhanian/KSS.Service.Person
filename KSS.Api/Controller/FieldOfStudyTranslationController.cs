using KSS.Dto;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    public class FieldOfStudyTranslationController : BaseController<FieldOfStudyTranslation, FieldOfStudyTranslationDto, FieldOfStudyTranslationDto, FieldOfStudyTranslationDto>
    {
        public FieldOfStudyTranslationController(IFieldOfStudyTranslationService service) : base(service) { }
    }
}
