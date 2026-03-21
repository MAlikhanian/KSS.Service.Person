using KSS.Dto;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    public class ReligionController : BaseController<Religion, ReligionDto, ReligionDto, ReligionDto>
    {
        public ReligionController(IReligionService service) : base(service) { }
    }
}
