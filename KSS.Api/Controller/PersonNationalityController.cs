using KSS.Dto;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    public class PersonNationalityController : BaseController<PersonNationality, PersonNationalityDto, PersonNationalityDto, PersonNationalityDto>
    {
        public PersonNationalityController(IPersonNationalityService service) : base(service) { }
    }
}
