using KSS.Dto;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    public class PersonStatusController : BaseController<PersonStatus, PersonStatusDto, PersonStatusDto, PersonStatusDto>
    {
        public PersonStatusController(IPersonStatusService service) : base(service) { }
    }
}
