using Microsoft.EntityFrameworkCore;
using KSS.Entity;

namespace KSS.Data.DbContexts
{
    public partial class MainDbContext
    {
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<DocumentTypeTranslation> DocumentTypeTranslations { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<EducationLevel> EducationLevels { get; set; }
        public DbSet<EducationLevelTranslation> EducationLevelTranslations { get; set; }
        public DbSet<FieldOfStudy> FieldsOfStudy { get; set; }
        public DbSet<FieldOfStudyTranslation> FieldOfStudyTranslations { get; set; }
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<InstitutionTranslation> InstitutionTranslations { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<EducationDocument> EducationDocuments { get; set; }
        public DbSet<EducationDocumentType> EducationDocumentTypes { get; set; }
        public DbSet<EducationDocumentTypeTranslation> EducationDocumentTypeTranslations { get; set; }
    }
}
