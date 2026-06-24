using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class EmploymentPositionService : BaseService<EmploymentPosition, EmploymentPositionDto, EmploymentPositionDto, EmploymentPositionDto>, IEmploymentPositionService
    {
        public EmploymentPositionService(IMapper mapper, IEmploymentPositionRepository repository) : base(mapper, repository) { }
    }
}
