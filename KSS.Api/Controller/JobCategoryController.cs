using KSS.Dto;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    public class JobCategoryController : BaseController<JobCategory, JobCategoryDto, JobCategoryDto, JobCategoryDto>
    {
        public JobCategoryController(IJobCategoryService service) : base(service) { }
    }
}
