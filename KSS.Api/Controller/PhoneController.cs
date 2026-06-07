using KSS.Dto;
using KSS.Helper.CustomAttribute;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    [PermissionGroup("Information")]
    public class PhoneController : BaseController<Phone, PhoneDto, PhoneDto, PhoneDto>
    {
        public PhoneController(IPhoneService service) : base(service) { }
    }
}
