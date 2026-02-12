using KSS.Dto;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    public class JobCategoryTranslationController : BaseController<JobCategoryTranslation, JobCategoryTranslationDto, JobCategoryTranslationDto, JobCategoryTranslationDto>
    {
        public JobCategoryTranslationController(IJobCategoryTranslationService service) : base(service) { }
    }
}
