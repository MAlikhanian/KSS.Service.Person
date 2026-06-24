using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class ProfessionalTrainingCertificateIssuerTranslationService : BaseService<ProfessionalTrainingCertificateIssuerTranslation, ProfessionalTrainingCertificateIssuerTranslationDto, ProfessionalTrainingCertificateIssuerTranslationDto, ProfessionalTrainingCertificateIssuerTranslationDto>, IProfessionalTrainingCertificateIssuerTranslationService
    {
        public ProfessionalTrainingCertificateIssuerTranslationService(IMapper mapper, IProfessionalTrainingCertificateIssuerTranslationRepository repository) : base(mapper, repository) { }
    }
}
