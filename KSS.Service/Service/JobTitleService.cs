using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class JobTitleService : BaseService<JobTitle, JobTitleDto, JobTitleDto, JobTitleDto>, IJobTitleService
    {
        public JobTitleService(IMapper mapper, IJobTitleRepository repository) : base(mapper, repository) { }
    }
}
