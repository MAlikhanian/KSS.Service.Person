using KSS.Dto;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    public class JobDepartmentTranslationController : BaseController<JobDepartmentTranslation, JobDepartmentTranslationDto, JobDepartmentTranslationDto, JobDepartmentTranslationDto>
    {
        public JobDepartmentTranslationController(IJobDepartmentTranslationService service) : base(service) { }
    }
}
