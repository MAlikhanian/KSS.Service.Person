using KSS.Dto;
using KSS.Helper.CustomAttribute;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    [PermissionGroup("Information")]
    public class ProfessionalTrainingDocumentTypeController : BaseController<ProfessionalTrainingDocumentType, ProfessionalTrainingDocumentTypeDto, ProfessionalTrainingDocumentTypeDto, ProfessionalTrainingDocumentTypeDto>
    {
        public ProfessionalTrainingDocumentTypeController(IProfessionalTrainingDocumentTypeService service) : base(service) { }
    }
}
