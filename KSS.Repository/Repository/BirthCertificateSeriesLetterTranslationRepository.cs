using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class BirthCertificateSeriesLetterTranslationRepository : BaseRepository<PersonDbContext, BirthCertificateSeriesLetterTranslation>, IBirthCertificateSeriesLetterTranslationRepository
    {
        public BirthCertificateSeriesLetterTranslationRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
