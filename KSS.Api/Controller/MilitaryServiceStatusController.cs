using KSS.Dto;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    public class MilitaryServiceStatusController : BaseController<MilitaryServiceStatus, MilitaryServiceStatusDto, MilitaryServiceStatusDto, MilitaryServiceStatusDto>
    {
        public MilitaryServiceStatusController(IMilitaryServiceStatusService service) : base(service) { }
    }
}
