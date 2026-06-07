using KSS.Dto;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    public class TranslationController : BaseController<Translation, TranslationDto, TranslationDto, TranslationDto>
    {
        public TranslationController(ITranslationService service) : base(service) { }
    }
}
