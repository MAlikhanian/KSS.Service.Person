using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class EmploymentActivityFieldService : BaseService<EmploymentActivityField, EmploymentActivityFieldDto, EmploymentActivityFieldDto, EmploymentActivityFieldDto>, IEmploymentActivityFieldService
    {
        public EmploymentActivityFieldService(IMapper mapper, IEmploymentActivityFieldRepository repository) : base(mapper, repository) { }
    }
}
