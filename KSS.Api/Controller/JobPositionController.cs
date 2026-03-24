using KSS.Dto;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    public class JobPositionController : BaseController<JobPosition, JobPositionDto, JobPositionDto, JobPositionDto>
    {
        public JobPositionController(IJobPositionService service) : base(service) { }
    }
}
