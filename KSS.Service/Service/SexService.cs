using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class SexService : BaseService<Sex, SexDto, SexDto, SexDto>, ISexService
    {
        public SexService(IMapper mapper, ISexRepository repository) : base(mapper, repository) { }
    }
}
