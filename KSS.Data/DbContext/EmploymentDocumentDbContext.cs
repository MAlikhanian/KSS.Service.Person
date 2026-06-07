using Microsoft.EntityFrameworkCore;
using KSS.Entity;

namespace KSS.Data.DbContexts
{
    public partial class MainDbContext
    {
        public DbSet<EmploymentDocument> EmploymentDocuments { get; set; }
        public DbSet<EmploymentDocumentType> EmploymentDocumentTypes { get; set; }
        public DbSet<EmploymentDocumentTypeTranslation> EmploymentDocumentTypeTranslations { get; set; }
    }
}
