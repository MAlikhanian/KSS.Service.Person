using KSS.Dto;
using KSS.Helper.CustomAttribute;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    [PermissionGroup("Information")]
    public class ProfessionalTrainingTypeTranslationController : BaseController<ProfessionalTrainingTypeTranslation, ProfessionalTrainingTypeTranslationDto, ProfessionalTrainingTypeTranslationDto, ProfessionalTrainingTypeTranslationDto>
    {
        public ProfessionalTrainingTypeTranslationController(IProfessionalTrainingTypeTranslationService service) : base(service) { }
    }
}
