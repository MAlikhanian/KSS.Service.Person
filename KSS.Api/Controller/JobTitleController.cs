using KSS.Dto;
using KSS.Helper.CustomAttribute;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    [PermissionGroup("Information")]
    public class JobTitleController : BaseController<JobTitle, JobTitleDto, JobTitleDto, JobTitleDto>
    {
        public JobTitleController(IJobTitleService service) : base(service) { }
    }
}
