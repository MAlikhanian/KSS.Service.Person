using KSS.Dto;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    public class InstitutionTranslationController : BaseController<InstitutionTranslation, InstitutionTranslationDto, InstitutionTranslationDto, InstitutionTranslationDto>
    {
        public InstitutionTranslationController(IInstitutionTranslationService service) : base(service) { }
    }
}
