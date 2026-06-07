using KSS.Dto;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    public class EducationDocumentController : BaseController<EducationDocument, EducationDocumentListDto, EducationDocumentAddDto, EducationDocumentAddDto>
    {
        public EducationDocumentController(IEducationDocumentService service) : base(service) { }
    }
}
