using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class ProfessionalTrainingTypeTranslationService : BaseService<ProfessionalTrainingTypeTranslation, ProfessionalTrainingTypeTranslationDto, ProfessionalTrainingTypeTranslationDto, ProfessionalTrainingTypeTranslationDto>, IProfessionalTrainingTypeTranslationService
    {
        public ProfessionalTrainingTypeTranslationService(IMapper mapper, IProfessionalTrainingTypeTranslationRepository repository) : base(mapper, repository) { }
    }
}
