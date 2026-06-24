using KSS.Dto;
using KSS.Helper.CustomAttribute;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    [PermissionGroup("Information")]
    public class EmploymentPositionController : BaseController<EmploymentPosition, EmploymentPositionDto, EmploymentPositionDto, EmploymentPositionDto>
    {
        public EmploymentPositionController(IEmploymentPositionService service) : base(service) { }
    }
}
