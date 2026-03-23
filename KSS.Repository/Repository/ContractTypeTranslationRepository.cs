using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class ContractTypeTranslationRepository : BaseRepository<PersonDbContext, ContractTypeTranslation>, IContractTypeTranslationRepository
    {
        public ContractTypeTranslationRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
