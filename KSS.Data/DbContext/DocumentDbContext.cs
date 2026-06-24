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
        public DbSet<ProfessionalTraining> ProfessionalTrainings { get; set; }
        public DbSet<ProfessionalTrainingDocument> ProfessionalTrainingDocuments { get; set; }
        public DbSet<ProfessionalTrainingType> ProfessionalTrainingTypes { get; set; }
        public DbSet<ProfessionalTrainingTypeTranslation> ProfessionalTrainingTypeTranslations { get; set; }
        public DbSet<ProfessionalTrainingCertificateIssuer> ProfessionalTrainingCertificateIssuers { get; set; }
        public DbSet<ProfessionalTrainingCertificateIssuerTranslation> ProfessionalTrainingCertificateIssuerTranslations { get; set; }
        public DbSet<ProfessionalTrainingDocumentType> ProfessionalTrainingDocumentTypes { get; set; }
        public DbSet<ProfessionalTrainingDocumentTypeTranslation> ProfessionalTrainingDocumentTypeTranslations { get; set; }
    }
}
