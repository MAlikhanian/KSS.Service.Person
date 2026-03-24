using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class JobPositionService : BaseService<JobPosition, JobPositionDto, JobPositionDto, JobPositionDto>, IJobPositionService
    {
        public JobPositionService(IMapper mapper, IJobPositionRepository repository) : base(mapper, repository) { }
    }
}
