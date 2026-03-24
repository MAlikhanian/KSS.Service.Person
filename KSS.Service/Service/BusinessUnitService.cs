using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class BusinessUnitService : BaseService<BusinessUnit, BusinessUnitDto, BusinessUnitDto, BusinessUnitDto>, IBusinessUnitService
    {
        public BusinessUnitService(IMapper mapper, IBusinessUnitRepository repository) : base(mapper, repository) { }
    }
}
