using KSS.Dto;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    public class EmploymentController : BaseController<Employment, EmploymentDto, EmploymentDto, EmploymentDto>
    {
        public EmploymentController(IEmploymentService service) : base(service) { }
    }
}
