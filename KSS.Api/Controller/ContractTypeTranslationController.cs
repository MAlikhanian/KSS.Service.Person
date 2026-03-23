using KSS.Dto;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    public class ContractTypeTranslationController : BaseController<ContractTypeTranslation, ContractTypeTranslationDto, ContractTypeTranslationDto, ContractTypeTranslationDto>
    {
        public ContractTypeTranslationController(IContractTypeTranslationService service) : base(service) { }
    }
}
