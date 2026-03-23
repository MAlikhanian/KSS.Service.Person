using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class ContractTypeService : BaseService<ContractType, ContractTypeDto, ContractTypeDto, ContractTypeDto>, IContractTypeService
    {
        public ContractTypeService(IMapper mapper, IContractTypeRepository repository) : base(mapper, repository) { }
    }
}
