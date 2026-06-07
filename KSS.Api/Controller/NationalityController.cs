using KSS.Dto;
using KSS.Helper.CustomAttribute;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    [PermissionGroup("Information")]
    public class NationalityController : BaseController<Nationality, NationalityDto, NationalityDto, NationalityDto>
    {
        public NationalityController(INationalityService service) : base(service) { }
    }
}
