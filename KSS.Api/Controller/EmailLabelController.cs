using KSS.Dto;
using KSS.Helper.CustomAttribute;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    [PermissionGroup("Information")]
    public class EmailLabelController : BaseController<EmailLabel, EmailLabelDto, EmailLabelDto, EmailLabelDto>
    {
        public EmailLabelController(IEmailLabelService service) : base(service) { }
    }
}
