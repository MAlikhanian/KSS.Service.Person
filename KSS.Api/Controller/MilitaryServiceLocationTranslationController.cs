using KSS.Dto;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    public class MilitaryServiceLocationTranslationController : BaseController<MilitaryServiceLocationTranslation, MilitaryServiceLocationTranslationDto, MilitaryServiceLocationTranslationDto, MilitaryServiceLocationTranslationDto>
    {
        public MilitaryServiceLocationTranslationController(IMilitaryServiceLocationTranslationService service) : base(service) { }
    }
}
