using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class ContractTypeTranslationService : BaseService<ContractTypeTranslation, ContractTypeTranslationDto, ContractTypeTranslationDto, ContractTypeTranslationDto>, IContractTypeTranslationService
    {
        public ContractTypeTranslationService(IMapper mapper, IContractTypeTranslationRepository repository) : base(mapper, repository) { }
    }
}
