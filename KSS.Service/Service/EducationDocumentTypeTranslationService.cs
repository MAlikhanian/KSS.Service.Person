using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class EducationDocumentTypeTranslationService : BaseService<EducationDocumentTypeTranslation, EducationDocumentTypeTranslationDto, EducationDocumentTypeTranslationDto, EducationDocumentTypeTranslationDto>, IEducationDocumentTypeTranslationService
    {
        public EducationDocumentTypeTranslationService(IMapper mapper, IEducationDocumentTypeTranslationRepository repository) : base(mapper, repository) { }
    }
}
