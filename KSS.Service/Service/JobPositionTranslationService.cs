using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class JobPositionTranslationService : BaseService<JobPositionTranslation, JobPositionTranslationDto, JobPositionTranslationDto, JobPositionTranslationDto>, IJobPositionTranslationService
    {
        public JobPositionTranslationService(IMapper mapper, IJobPositionTranslationRepository repository) : base(mapper, repository) { }
    }
}
