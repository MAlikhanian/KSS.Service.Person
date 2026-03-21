using KSS.Dto;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    public class ReligionTranslationController : BaseController<ReligionTranslation, ReligionTranslationDto, ReligionTranslationDto, ReligionTranslationDto>
    {
        public ReligionTranslationController(IReligionTranslationService service) : base(service) { }
    }
}
