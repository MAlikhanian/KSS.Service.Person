using KSS.Dto;
using KSS.Helper.CustomAttribute;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    [PermissionGroup("Information")]
    public class BusinessSectorController : BaseController<BusinessSector, BusinessSectorDto, BusinessSectorDto, BusinessSectorDto>
    {
        public BusinessSectorController(IBusinessSectorService service) : base(service) { }
    }
}
