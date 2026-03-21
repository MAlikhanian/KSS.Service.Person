using KSS.Dto;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    public class MilitaryServiceLocationController : BaseController<MilitaryServiceLocation, MilitaryServiceLocationDto, MilitaryServiceLocationDto, MilitaryServiceLocationDto>
    {
        public MilitaryServiceLocationController(IMilitaryServiceLocationService service) : base(service) { }
    }
}
