using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class MaritalStatusService : BaseService<MaritalStatus, MaritalStatusDto, MaritalStatusDto, MaritalStatusDto>, IMaritalStatusService
    {
        public MaritalStatusService(IMapper mapper, IMaritalStatusRepository repository) : base(mapper, repository) { }
    }
}
