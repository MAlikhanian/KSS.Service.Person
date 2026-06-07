using KSS.Dto;
using KSS.Helper.CustomAttribute;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    [PermissionGroup("Information")]
    public class EducationController : BaseController<Education, EducationListDto, EducationAddDto, EducationUpdateDto>
    {
        public EducationController(IEducationService service) : base(service) { }
    }
}
