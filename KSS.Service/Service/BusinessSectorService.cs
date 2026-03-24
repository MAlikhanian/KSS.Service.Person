using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class BusinessSectorService : BaseService<BusinessSector, BusinessSectorDto, BusinessSectorDto, BusinessSectorDto>, IBusinessSectorService
    {
        public BusinessSectorService(IMapper mapper, IBusinessSectorRepository repository) : base(mapper, repository) { }
    }
}
