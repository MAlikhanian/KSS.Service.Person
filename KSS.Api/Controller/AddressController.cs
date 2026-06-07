using KSS.Dto;
using KSS.Helper.CustomAttribute;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    [PermissionGroup("Information")]
    public class AddressController : BaseController<Address, AddressDto, AddressDto, AddressDto>
    {
        public AddressController(IAddressService service) : base(service) { }
    }
}
