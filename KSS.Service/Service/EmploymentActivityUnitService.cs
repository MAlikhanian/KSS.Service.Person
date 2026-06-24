using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class EmploymentActivityUnitService : BaseService<EmploymentActivityUnit, EmploymentActivityUnitDto, EmploymentActivityUnitDto, EmploymentActivityUnitDto>, IEmploymentActivityUnitService
    {
        public EmploymentActivityUnitService(IMapper mapper, IEmploymentActivityUnitRepository repository) : base(mapper, repository) { }
    }
}
