using KSS.Dto;
using KSS.Helper.CustomAttribute;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    [PermissionGroup("Information")]
    public class MilitaryServiceStatusController : BaseController<MilitaryServiceStatus, MilitaryServiceStatusDto, MilitaryServiceStatusDto, MilitaryServiceStatusDto>
    {
        public MilitaryServiceStatusController(IMilitaryServiceStatusService service) : base(service) { }
    }
}
