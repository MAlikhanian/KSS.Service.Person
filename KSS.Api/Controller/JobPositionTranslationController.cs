using KSS.Dto;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    public class JobPositionTranslationController : BaseController<JobPositionTranslation, JobPositionTranslationDto, JobPositionTranslationDto, JobPositionTranslationDto>
    {
        public JobPositionTranslationController(IJobPositionTranslationService service) : base(service) { }
    }
}
