using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class EmploymentService : BaseService<Employment, EmploymentDto, EmploymentDto, EmploymentDto>, IEmploymentService
    {
        public EmploymentService(IMapper mapper, IEmploymentRepository repository) : base(mapper, repository) { }
    }
}
