using KSS.Dto;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    public class EmploymentDocumentController : BaseController<EmploymentDocument, EmploymentDocumentListDto, EmploymentDocumentAddDto, EmploymentDocumentAddDto>
    {
        public EmploymentDocumentController(IEmploymentDocumentService service) : base(service) { }
    }
}
