using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class DocumentTypeTranslationService : BaseService<DocumentTypeTranslation, DocumentTypeTranslationDto, DocumentTypeTranslationDto, DocumentTypeTranslationDto>, IDocumentTypeTranslationService
    {
        public DocumentTypeTranslationService(IMapper mapper, IDocumentTypeTranslationRepository repository) : base(mapper, repository) { }
    }
}
