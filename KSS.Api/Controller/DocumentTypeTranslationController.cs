using KSS.Dto;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    public class DocumentTypeTranslationController : BaseController<DocumentTypeTranslation, DocumentTypeTranslationDto, DocumentTypeTranslationDto, DocumentTypeTranslationDto>
    {
        public DocumentTypeTranslationController(IDocumentTypeTranslationService service) : base(service) { }
    }
}
