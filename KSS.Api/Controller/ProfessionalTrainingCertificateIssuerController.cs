using KSS.Dto;
using KSS.Helper.CustomAttribute;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    [PermissionGroup("Information")]
    public class ProfessionalTrainingCertificateIssuerController : BaseController<ProfessionalTrainingCertificateIssuer, ProfessionalTrainingCertificateIssuerDto, ProfessionalTrainingCertificateIssuerDto, ProfessionalTrainingCertificateIssuerDto>
    {
        public ProfessionalTrainingCertificateIssuerController(IProfessionalTrainingCertificateIssuerService service) : base(service) { }
    }
}
