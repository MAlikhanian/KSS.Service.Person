using KSS.Dto;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    public class JobTitleTranslationController : BaseController<JobTitleTranslation, JobTitleTranslationDto, JobTitleTranslationDto, JobTitleTranslationDto>
    {
        public JobTitleTranslationController(IJobTitleTranslationService service) : base(service) { }
    }
}
