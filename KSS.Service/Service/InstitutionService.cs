using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class InstitutionService : BaseService<Institution, InstitutionDto, Institution, Institution>, IInstitutionService
    {
        public InstitutionService(IMapper mapper, IInstitutionRepository repository) : base(mapper, repository) { }
    }
}
