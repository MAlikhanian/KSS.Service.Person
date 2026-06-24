using KSS.Dto;
using KSS.Helper.CustomAttribute;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    [PermissionGroup("Information")]
    public class ProfessionalTrainingTypeController : BaseController<ProfessionalTrainingType, ProfessionalTrainingTypeDto, ProfessionalTrainingTypeDto, ProfessionalTrainingTypeDto>
    {
        public ProfessionalTrainingTypeController(IProfessionalTrainingTypeService service) : base(service) { }
    }
}
