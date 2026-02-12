using KSS.Dto;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    public class SexController : BaseController<Sex, SexDto, SexDto, SexDto>
    {
        public SexController(ISexService service) : base(service) { }
    }
}
