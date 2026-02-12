using KSS.Dto;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    public class PersonController : BaseController<Person, PersonDto, PersonDto, PersonDto>
    {
        public PersonController(IPersonService service) : base(service)
        {
        }
    }
}
