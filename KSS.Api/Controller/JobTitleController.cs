using KSS.Dto;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    public class JobTitleController : BaseController<JobTitle, JobTitleDto, JobTitleDto, JobTitleDto>
    {
        public JobTitleController(IJobTitleService service) : base(service) { }
    }
}
