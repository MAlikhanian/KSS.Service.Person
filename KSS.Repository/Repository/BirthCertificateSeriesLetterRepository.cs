using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class BirthCertificateSeriesLetterRepository : BaseRepository<PersonDbContext, BirthCertificateSeriesLetter>, IBirthCertificateSeriesLetterRepository
    {
        public BirthCertificateSeriesLetterRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
