using KSS.Dto;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    public class ContractTypeController : BaseController<ContractType, ContractTypeDto, ContractTypeDto, ContractTypeDto>
    {
        public ContractTypeController(IContractTypeService service) : base(service) { }
    }
}
