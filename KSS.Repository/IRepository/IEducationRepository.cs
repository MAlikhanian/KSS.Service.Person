using KSS.Entity;

namespace KSS.Repository.IRepository
{
    public interface IEducationRepository : IBaseRepository<Education>
    {
        Task<IEnumerable<Education>> ToListByPersonAsync(Guid personId);
    }
}
