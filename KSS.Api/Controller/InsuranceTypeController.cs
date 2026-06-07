using KSS.Dto;
using KSS.Helper.CustomAttribute;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    [PermissionGroup("Information")]
    public class InsuranceTypeController : BaseController<InsuranceType, InsuranceTypeDto, InsuranceTypeDto, InsuranceTypeDto>
    {
        public InsuranceTypeController(IInsuranceTypeService service) : base(service) { }
    }
}
