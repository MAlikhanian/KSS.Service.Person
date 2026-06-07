using KSS.Dto;
using KSS.Helper.CustomAttribute;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    [PermissionGroup("Information")]
    public class MilitaryServiceLocationController : BaseController<MilitaryServiceLocation, MilitaryServiceLocationDto, MilitaryServiceLocationDto, MilitaryServiceLocationDto>
    {
        public MilitaryServiceLocationController(IMilitaryServiceLocationService service) : base(service) { }
    }
}
