using KSS.Dto;
using KSS.Helper.CustomAttribute;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    [PermissionGroup("Information")]
    public class ProfessionalTrainingDocumentController : BaseController<ProfessionalTrainingDocument, ProfessionalTrainingDocumentListDto, ProfessionalTrainingDocumentAddDto, ProfessionalTrainingDocumentAddDto>
    {
        public ProfessionalTrainingDocumentController(IProfessionalTrainingDocumentService service) : base(service) { }
    }
}
