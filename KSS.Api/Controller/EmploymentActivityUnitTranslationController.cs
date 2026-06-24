using KSS.Dto;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    public class EmploymentActivityUnitTranslationController : BaseController<EmploymentActivityUnitTranslation, EmploymentActivityUnitTranslationDto, EmploymentActivityUnitTranslationDto, EmploymentActivityUnitTranslationDto>
    {
        public EmploymentActivityUnitTranslationController(IEmploymentActivityUnitTranslationService service) : base(service) { }
    }
}
