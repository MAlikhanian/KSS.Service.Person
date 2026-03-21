using KSS.Dto;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    public class InsuranceTypeController : BaseController<InsuranceType, InsuranceTypeDto, InsuranceTypeDto, InsuranceTypeDto>
    {
        public InsuranceTypeController(IInsuranceTypeService service) : base(service) { }
    }
}
