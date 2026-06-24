using KSS.Entity;

namespace KSS.Repository.IRepository
{
    public interface IProfessionalTrainingRepository : IBaseRepository<ProfessionalTraining>
    {
        Task<IEnumerable<ProfessionalTraining>> ToListByPersonAsync(Guid personId);
    }
}
