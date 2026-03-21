using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class InsuranceTypeService : BaseService<InsuranceType, InsuranceTypeDto, InsuranceTypeDto, InsuranceTypeDto>, IInsuranceTypeService
    {
        public InsuranceTypeService(IMapper mapper, IInsuranceTypeRepository repository) : base(mapper, repository) { }
    }
}
