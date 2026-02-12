using KSS.Dto;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    public class PersonTranslationController : BaseController<PersonTranslation, PersonTranslationDto, PersonTranslationDto, PersonTranslationDto>
    {
        public PersonTranslationController(IPersonTranslationService service) : base(service) { }
    }
}
