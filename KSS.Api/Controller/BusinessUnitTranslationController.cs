using KSS.Dto;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    public class BusinessUnitTranslationController : BaseController<BusinessUnitTranslation, BusinessUnitTranslationDto, BusinessUnitTranslationDto, BusinessUnitTranslationDto>
    {
        public BusinessUnitTranslationController(IBusinessUnitTranslationService service) : base(service) { }
    }
}
