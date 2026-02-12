using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class JobDepartmentService : BaseService<JobDepartment, JobDepartmentDto, JobDepartmentDto, JobDepartmentDto>, IJobDepartmentService
    {
        public JobDepartmentService(IMapper mapper, IJobDepartmentRepository repository) : base(mapper, repository) { }
    }
}
