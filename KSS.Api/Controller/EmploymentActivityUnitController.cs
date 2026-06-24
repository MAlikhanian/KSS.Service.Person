using KSS.Dto;
using KSS.Helper.CustomAttribute;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    [PermissionGroup("Information")]
    public class EmploymentActivityUnitController : BaseController<EmploymentActivityUnit, EmploymentActivityUnitDto, EmploymentActivityUnitDto, EmploymentActivityUnitDto>
    {
        public EmploymentActivityUnitController(IEmploymentActivityUnitService service) : base(service) { }
    }
}
