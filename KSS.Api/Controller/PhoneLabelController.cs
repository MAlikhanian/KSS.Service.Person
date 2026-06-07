using KSS.Dto;
using KSS.Helper.CustomAttribute;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    [PermissionGroup("Information")]
    public class PhoneLabelController : BaseController<PhoneLabel, PhoneLabelDto, PhoneLabelDto, PhoneLabelDto>
    {
        public PhoneLabelController(IPhoneLabelService service) : base(service) { }
    }
}
