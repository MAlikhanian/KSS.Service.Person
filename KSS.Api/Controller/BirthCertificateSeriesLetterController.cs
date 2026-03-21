using KSS.Dto;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    public class BirthCertificateSeriesLetterController : BaseController<BirthCertificateSeriesLetter, BirthCertificateSeriesLetterDto, BirthCertificateSeriesLetterDto, BirthCertificateSeriesLetterDto>
    {
        public BirthCertificateSeriesLetterController(IBirthCertificateSeriesLetterService service) : base(service) { }
    }
}
