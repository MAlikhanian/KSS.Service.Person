using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class PhoneService : BaseService<Phone, PhoneDto, PhoneDto, PhoneDto>, IPhoneService
    {
        public PhoneService(IMapper mapper, IPhoneRepository repository) : base(mapper, repository) { }
    }
}
