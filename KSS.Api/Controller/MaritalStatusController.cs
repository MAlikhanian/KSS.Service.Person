using KSS.Dto;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    public class MaritalStatusController : BaseController<MaritalStatus, MaritalStatusDto, MaritalStatusDto, MaritalStatusDto>
    {
        public MaritalStatusController(IMaritalStatusService service) : base(service) { }
    }
}
