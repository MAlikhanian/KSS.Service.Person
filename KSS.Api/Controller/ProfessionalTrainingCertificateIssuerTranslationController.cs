using KSS.Dto;
using KSS.Helper.CustomAttribute;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    [PermissionGroup("Information")]
    public class ProfessionalTrainingCertificateIssuerTranslationController : BaseController<ProfessionalTrainingCertificateIssuerTranslation, ProfessionalTrainingCertificateIssuerTranslationDto, ProfessionalTrainingCertificateIssuerTranslationDto, ProfessionalTrainingCertificateIssuerTranslationDto>
    {
        public ProfessionalTrainingCertificateIssuerTranslationController(IProfessionalTrainingCertificateIssuerTranslationService service) : base(service) { }
    }
}
