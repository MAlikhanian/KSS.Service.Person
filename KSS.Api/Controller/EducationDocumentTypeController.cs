using KSS.Dto;
using KSS.Helper.CustomAttribute;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    [PermissionGroup("Information")]
    public class EducationDocumentTypeController : BaseController<EducationDocumentType, EducationDocumentTypeDto, EducationDocumentTypeDto, EducationDocumentTypeDto>
    {
        public EducationDocumentTypeController(IEducationDocumentTypeService service) : base(service) { }
    }
}
