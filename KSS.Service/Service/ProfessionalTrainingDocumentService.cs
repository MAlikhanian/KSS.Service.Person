using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class ProfessionalTrainingDocumentService : BaseService<ProfessionalTrainingDocument, ProfessionalTrainingDocumentListDto, ProfessionalTrainingDocumentAddDto, ProfessionalTrainingDocumentAddDto>, IProfessionalTrainingDocumentService
    {
        public ProfessionalTrainingDocumentService(IMapper mapper, IProfessionalTrainingDocumentRepository repository) : base(mapper, repository) { }
    }
}
