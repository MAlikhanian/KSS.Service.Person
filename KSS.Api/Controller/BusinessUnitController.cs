using KSS.Dto;
using KSS.Helper.CustomAttribute;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    [PermissionGroup("Information")]
    public class BusinessUnitController : BaseController<BusinessUnit, BusinessUnitDto, BusinessUnitDto, BusinessUnitDto>
    {
        public BusinessUnitController(IBusinessUnitService service) : base(service) { }
    }
}
