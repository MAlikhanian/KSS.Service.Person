using KSS.Dto;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    public class EducationDocumentTypeTranslationController : BaseController<EducationDocumentTypeTranslation, EducationDocumentTypeTranslationDto, EducationDocumentTypeTranslationDto, EducationDocumentTypeTranslationDto>
    {
        public EducationDocumentTypeTranslationController(IEducationDocumentTypeTranslationService service) : base(service) { }
    }
}
