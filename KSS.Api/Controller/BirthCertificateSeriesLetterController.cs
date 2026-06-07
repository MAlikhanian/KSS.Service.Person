using KSS.Dto;
using KSS.Helper.CustomAttribute;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    [PermissionGroup("Information")]
    public class BirthCertificateSeriesLetterController : BaseController<BirthCertificateSeriesLetter, BirthCertificateSeriesLetterDto, BirthCertificateSeriesLetterDto, BirthCertificateSeriesLetterDto>
    {
        public BirthCertificateSeriesLetterController(IBirthCertificateSeriesLetterService service) : base(service) { }
    }
}
