using KSS.Dto;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    public class JobDepartmentController : BaseController<JobDepartment, JobDepartmentDto, JobDepartmentDto, JobDepartmentDto>
    {
        public JobDepartmentController(IJobDepartmentService service) : base(service) { }
    }
}
