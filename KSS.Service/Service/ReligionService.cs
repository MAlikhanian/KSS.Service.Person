using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class ReligionService : BaseService<Religion, ReligionDto, ReligionDto, ReligionDto>, IReligionService
    {
        public ReligionService(IMapper mapper, IReligionRepository repository) : base(mapper, repository) { }
    }
}
