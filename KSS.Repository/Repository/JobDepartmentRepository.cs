using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class JobDepartmentRepository : BaseRepository<PersonDbContext, JobDepartment>, IJobDepartmentRepository
    {
        public JobDepartmentRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
