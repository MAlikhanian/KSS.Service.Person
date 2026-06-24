using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class ProfessionalTrainingCertificateIssuerRepository : BaseRepository<PersonDbContext, ProfessionalTrainingCertificateIssuer>, IProfessionalTrainingCertificateIssuerRepository
    {
        public ProfessionalTrainingCertificateIssuerRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
