using KSS.Dto;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    public class SexTranslationController : BaseController<SexTranslation, SexTranslationDto, SexTranslationDto, SexTranslationDto>
    {
        public SexTranslationController(ISexTranslationService service) : base(service) { }
    }
}
