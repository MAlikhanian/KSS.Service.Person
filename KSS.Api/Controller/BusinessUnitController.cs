using KSS.Dto;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    public class BusinessUnitController : BaseController<BusinessUnit, BusinessUnitDto, BusinessUnitDto, BusinessUnitDto>
    {
        public BusinessUnitController(IBusinessUnitService service) : base(service) { }
    }
}
