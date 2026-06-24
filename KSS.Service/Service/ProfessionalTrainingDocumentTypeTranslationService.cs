using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class ProfessionalTrainingDocumentTypeTranslationService : BaseService<ProfessionalTrainingDocumentTypeTranslation, ProfessionalTrainingDocumentTypeTranslationDto, ProfessionalTrainingDocumentTypeTranslationDto, ProfessionalTrainingDocumentTypeTranslationDto>, IProfessionalTrainingDocumentTypeTranslationService
    {
        public ProfessionalTrainingDocumentTypeTranslationService(IMapper mapper, IProfessionalTrainingDocumentTypeTranslationRepository repository) : base(mapper, repository) { }
    }
}
