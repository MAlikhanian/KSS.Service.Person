using KSS.Dto;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    public class PhoneLabelController : BaseController<PhoneLabel, PhoneLabelDto, PhoneLabelDto, PhoneLabelDto>
    {
        public PhoneLabelController(IPhoneLabelService service) : base(service) { }
    }
}
