using KSS.Dto;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    public class MilitaryServiceStatusTranslationController : BaseController<MilitaryServiceStatusTranslation, MilitaryServiceStatusTranslationDto, MilitaryServiceStatusTranslationDto, MilitaryServiceStatusTranslationDto>
    {
        public MilitaryServiceStatusTranslationController(IMilitaryServiceStatusTranslationService service) : base(service) { }
    }
}
