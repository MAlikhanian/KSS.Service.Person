using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class JobCategoryTranslationService : BaseService<JobCategoryTranslation, JobCategoryTranslationDto, JobCategoryTranslationDto, JobCategoryTranslationDto>, IJobCategoryTranslationService
    {
        public JobCategoryTranslationService(IMapper mapper, IJobCategoryTranslationRepository repository) : base(mapper, repository) { }
    }
}
