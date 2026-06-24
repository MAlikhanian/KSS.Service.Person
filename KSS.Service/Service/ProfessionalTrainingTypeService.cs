using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class ProfessionalTrainingTypeService : BaseService<ProfessionalTrainingType, ProfessionalTrainingTypeDto, ProfessionalTrainingTypeDto, ProfessionalTrainingTypeDto>, IProfessionalTrainingTypeService
    {
        public ProfessionalTrainingTypeService(IMapper mapper, IProfessionalTrainingTypeRepository repository) : base(mapper, repository) { }
    }
}
