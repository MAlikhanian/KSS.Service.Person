using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class ProfessionalTrainingCertificateIssuerService : BaseService<ProfessionalTrainingCertificateIssuer, ProfessionalTrainingCertificateIssuerDto, ProfessionalTrainingCertificateIssuerDto, ProfessionalTrainingCertificateIssuerDto>, IProfessionalTrainingCertificateIssuerService
    {
        public ProfessionalTrainingCertificateIssuerService(IMapper mapper, IProfessionalTrainingCertificateIssuerRepository repository) : base(mapper, repository) { }
    }
}
