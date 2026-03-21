using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class MilitaryServiceStatusService : BaseService<MilitaryServiceStatus, MilitaryServiceStatusDto, MilitaryServiceStatusDto, MilitaryServiceStatusDto>, IMilitaryServiceStatusService
    {
        public MilitaryServiceStatusService(IMapper mapper, IMilitaryServiceStatusRepository repository) : base(mapper, repository) { }
    }
}
