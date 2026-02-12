using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class JobDepartmentTranslationService : BaseService<JobDepartmentTranslation, JobDepartmentTranslationDto, JobDepartmentTranslationDto, JobDepartmentTranslationDto>, IJobDepartmentTranslationService
    {
        public JobDepartmentTranslationService(IMapper mapper, IJobDepartmentTranslationRepository repository) : base(mapper, repository) { }
    }
}
