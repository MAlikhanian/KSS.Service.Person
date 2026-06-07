using KSS.Dto;
using KSS.Helper.CustomAttribute;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    [PermissionGroup("Information")]
    public class EmploymentController : BaseController<Employment, EmploymentDto, EmploymentDto, EmploymentDto>
    {
        public EmploymentController(IEmploymentService service) : base(service) { }
    }
}
