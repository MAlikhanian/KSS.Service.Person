using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class InstitutionTranslationService : BaseService<InstitutionTranslation, InstitutionTranslationDto, InstitutionTranslationDto, InstitutionTranslationDto>, IInstitutionTranslationService
    {
        public InstitutionTranslationService(IMapper mapper, IInstitutionTranslationRepository repository) : base(mapper, repository) { }
    }
}
