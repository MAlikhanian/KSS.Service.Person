using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class ProfessionalTrainingDocumentTypeService : BaseService<ProfessionalTrainingDocumentType, ProfessionalTrainingDocumentTypeDto, ProfessionalTrainingDocumentTypeDto, ProfessionalTrainingDocumentTypeDto>, IProfessionalTrainingDocumentTypeService
    {
        public ProfessionalTrainingDocumentTypeService(IMapper mapper, IProfessionalTrainingDocumentTypeRepository repository) : base(mapper, repository) { }
    }
}
