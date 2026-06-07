using KSS.Dto;
using KSS.Helper.CustomAttribute;
using KSS.Entity;
using KSS.Service.IService;

namespace KSS.API.Controller
{
    [PermissionGroup("Information")]
    public class InstitutionController : BaseController<Institution, InstitutionDto, Institution, Institution>
    {
        public InstitutionController(IInstitutionService service) : base(service) { }
    }
}
