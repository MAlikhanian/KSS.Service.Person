using KSS.Dto;
using KSS.Helper.CustomAttribute;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    [PermissionGroup("Information")]
    public class ProfessionalTrainingController : BaseController<ProfessionalTraining, ProfessionalTrainingListDto, ProfessionalTrainingAddDto, ProfessionalTrainingUpdateDto>
    {
        public ProfessionalTrainingController(IProfessionalTrainingService service) : base(service) { }
    }
}
