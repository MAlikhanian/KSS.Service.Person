using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class MilitaryServiceLocationService : BaseService<MilitaryServiceLocation, MilitaryServiceLocationDto, MilitaryServiceLocationDto, MilitaryServiceLocationDto>, IMilitaryServiceLocationService
    {
        public MilitaryServiceLocationService(IMapper mapper, IMilitaryServiceLocationRepository repository) : base(mapper, repository) { }
    }
}
