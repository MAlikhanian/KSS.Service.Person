using KSS.Dto;
using KSS.Helper.CustomAttribute;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    [PermissionGroup("Information")]
    public class StatusController : BaseController<Status, StatusDto, StatusDto, StatusDto>
    {
        public StatusController(IStatusService service) : base(service) { }
    }
}
