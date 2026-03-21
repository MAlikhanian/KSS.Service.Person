using KSS.Dto;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    public class InsuranceTypeTranslationController : BaseController<InsuranceTypeTranslation, InsuranceTypeTranslationDto, InsuranceTypeTranslationDto, InsuranceTypeTranslationDto>
    {
        public InsuranceTypeTranslationController(IInsuranceTypeTranslationService service) : base(service) { }
    }
}
