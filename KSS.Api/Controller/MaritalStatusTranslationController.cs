using KSS.Dto;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    public class MaritalStatusTranslationController : BaseController<MaritalStatusTranslation, MaritalStatusTranslationDto, MaritalStatusTranslationDto, MaritalStatusTranslationDto>
    {
        public MaritalStatusTranslationController(IMaritalStatusTranslationService service) : base(service) { }
    }
}
