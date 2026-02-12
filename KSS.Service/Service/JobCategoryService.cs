using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class JobCategoryService : BaseService<JobCategory, JobCategoryDto, JobCategoryDto, JobCategoryDto>, IJobCategoryService
    {
        public JobCategoryService(IMapper mapper, IJobCategoryRepository repository) : base(mapper, repository) { }
    }
}
