using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class PersonStatusService : BaseService<PersonStatus, PersonStatusDto, PersonStatusDto, PersonStatusDto>, IPersonStatusService
    {
        public PersonStatusService(IMapper mapper, IPersonStatusRepository repository) : base(mapper, repository) { }
    }
}
