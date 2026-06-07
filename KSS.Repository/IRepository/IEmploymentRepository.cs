using KSS.Entity;

namespace KSS.Repository.IRepository
{
    public interface IEmploymentRepository : IBaseRepository<Employment>
    {
        Task<IEnumerable<Employment>> ToListByPersonAsync(Guid personId);
    }
}
