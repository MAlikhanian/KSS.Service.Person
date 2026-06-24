using KSS.Dto;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    public class EmploymentActivityFieldTranslationController : BaseController<EmploymentActivityFieldTranslation, EmploymentActivityFieldTranslationDto, EmploymentActivityFieldTranslationDto, EmploymentActivityFieldTranslationDto>
    {
        public EmploymentActivityFieldTranslationController(IEmploymentActivityFieldTranslationService service) : base(service) { }
    }
}
