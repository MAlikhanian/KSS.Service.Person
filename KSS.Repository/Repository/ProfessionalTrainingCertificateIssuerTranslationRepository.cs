using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class ProfessionalTrainingCertificateIssuerTranslationRepository : BaseRepository<PersonDbContext, ProfessionalTrainingCertificateIssuerTranslation>, IProfessionalTrainingCertificateIssuerTranslationRepository
    {
        public ProfessionalTrainingCertificateIssuerTranslationRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
