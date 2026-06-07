using KSS.Dto;
using KSS.Helper.CustomAttribute;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    [PermissionGroup("Information")]
    public class MaritalStatusController : BaseController<MaritalStatus, MaritalStatusDto, MaritalStatusDto, MaritalStatusDto>
    {
        public MaritalStatusController(IMaritalStatusService service) : base(service) { }
    }
}
