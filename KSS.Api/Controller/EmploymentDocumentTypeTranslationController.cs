using KSS.Dto;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    public class EmploymentDocumentTypeTranslationController : BaseController<EmploymentDocumentTypeTranslation, EmploymentDocumentTypeTranslationDto, EmploymentDocumentTypeTranslationDto, EmploymentDocumentTypeTranslationDto>
    {
        public EmploymentDocumentTypeTranslationController(IEmploymentDocumentTypeTranslationService service) : base(service) { }
    }
}
