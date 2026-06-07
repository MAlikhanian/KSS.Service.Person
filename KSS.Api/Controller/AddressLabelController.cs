using KSS.Dto;
using KSS.Helper.CustomAttribute;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    [PermissionGroup("Information")]
    public class AddressLabelController : BaseController<AddressLabel, AddressLabelDto, AddressLabelDto, AddressLabelDto>
    {
        public AddressLabelController(IAddressLabelService service) : base(service) { }
    }
}
