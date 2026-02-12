using KSS.Dto;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    public class AddressLabelController : BaseController<AddressLabel, AddressLabelDto, AddressLabelDto, AddressLabelDto>
    {
        public AddressLabelController(IAddressLabelService service) : base(service) { }
    }
}
