using KSS.Dto;
using KSS.Helper.CustomAttribute;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    [PermissionGroup("Information")]
    public class DocumentTypeController : BaseController<DocumentType, DocumentTypeDto, DocumentTypeDto, DocumentTypeDto>
    {
        public DocumentTypeController(IDocumentTypeService service) : base(service) { }
    }
}
