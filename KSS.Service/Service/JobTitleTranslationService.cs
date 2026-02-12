using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class JobTitleTranslationService : BaseService<JobTitleTranslation, JobTitleTranslationDto, JobTitleTranslationDto, JobTitleTranslationDto>, IJobTitleTranslationService
    {
        public JobTitleTranslationService(IMapper mapper, IJobTitleTranslationRepository repository) : base(mapper, repository) { }
    }
}
