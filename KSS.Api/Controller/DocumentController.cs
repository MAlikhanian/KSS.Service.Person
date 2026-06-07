using KSS.Dto;
using KSS.Helper.CustomAttribute;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    [PermissionGroup("Information")]
    public class DocumentController : BaseController<Document, DocumentListDto, DocumentAddDto, DocumentUpdateDto>
    {
        public DocumentController(IDocumentService service) : base(service) { }
    }
}
