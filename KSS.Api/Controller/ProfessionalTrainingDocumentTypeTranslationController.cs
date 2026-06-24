using KSS.Dto;
using KSS.Helper.CustomAttribute;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    [PermissionGroup("Information")]
    public class ProfessionalTrainingDocumentTypeTranslationController : BaseController<ProfessionalTrainingDocumentTypeTranslation, ProfessionalTrainingDocumentTypeTranslationDto, ProfessionalTrainingDocumentTypeTranslationDto, ProfessionalTrainingDocumentTypeTranslationDto>
    {
        public ProfessionalTrainingDocumentTypeTranslationController(IProfessionalTrainingDocumentTypeTranslationService service) : base(service) { }
    }
}
