using KSS.Dto;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    public class BusinessSectorTranslationController : BaseController<BusinessSectorTranslation, BusinessSectorTranslationDto, BusinessSectorTranslationDto, BusinessSectorTranslationDto>
    {
        public BusinessSectorTranslationController(IBusinessSectorTranslationService service) : base(service) { }
    }
}
