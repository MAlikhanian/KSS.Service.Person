using KSS.Dto;
using KSS.Helper.CustomAttribute;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    [PermissionGroup("Information")]
    public class EmploymentDocumentTypeController : BaseController<EmploymentDocumentType, EmploymentDocumentTypeDto, EmploymentDocumentTypeDto, EmploymentDocumentTypeDto>
    {
        public EmploymentDocumentTypeController(IEmploymentDocumentTypeService service) : base(service) { }
    }
}
