using KSS.Dto;
using KSS.Helper.CustomAttribute;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    [PermissionGroup("Information")]
    public class EmailController : BaseController<Email, EmailDto, EmailDto, EmailDto>
    {
        public EmailController(IEmailService service) : base(service) { }
    }
}
