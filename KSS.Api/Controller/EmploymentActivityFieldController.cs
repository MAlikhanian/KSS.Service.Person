using KSS.Dto;
using KSS.Helper.CustomAttribute;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    [PermissionGroup("Information")]
    public class EmploymentActivityFieldController : BaseController<EmploymentActivityField, EmploymentActivityFieldDto, EmploymentActivityFieldDto, EmploymentActivityFieldDto>
    {
        public EmploymentActivityFieldController(IEmploymentActivityFieldService service) : base(service) { }
    }
}
