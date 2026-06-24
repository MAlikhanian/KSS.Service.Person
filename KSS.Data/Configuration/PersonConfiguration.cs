using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KSS.Entity;

namespace KSS.Data.Configuration
{
    public class ReligionConfiguration : IEntityTypeConfiguration<Religion>
    {
        public void Configure(EntityTypeBuilder<Religion> b)
        {
            b.HasMany(x => x.Translations).WithOne(x => x.Religion).HasForeignKey(x => x.ReligionId).OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class ReligionTranslationConfiguration : IEntityTypeConfiguration<ReligionTranslation>
    {
        public void Configure(EntityTypeBuilder<ReligionTranslation> b)
        {
            b.HasKey(x => new { x.ReligionId, x.LanguageId });
        }
    }

    public class BirthCertificateSeriesLetterConfiguration : IEntityTypeConfiguration<BirthCertificateSeriesLetter>
    {
        public void Configure(EntityTypeBuilder<BirthCertificateSeriesLetter> b)
        {
            b.HasMany(x => x.Translations).WithOne(x => x.BirthCertificateSeriesLetter).HasForeignKey(x => x.BirthCertificateSeriesLetterId).OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class BirthCertificateSeriesLetterTranslationConfiguration : IEntityTypeConfiguration<BirthCertificateSeriesLetterTranslation>
    {
        public void Configure(EntityTypeBuilder<BirthCertificateSeriesLetterTranslation> b)
        {
            b.HasKey(x => new { x.BirthCertificateSeriesLetterId, x.LanguageId });
        }
    }

    public class SexConfiguration : IEntityTypeConfiguration<Sex>
    {
        public void Configure(EntityTypeBuilder<Sex> b)
        {
            b.HasMany(x => x.Translations).WithOne(x => x.Sex).HasForeignKey(x => x.SexId).OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class SexTranslationConfiguration : IEntityTypeConfiguration<SexTranslation>
    {
        public void Configure(EntityTypeBuilder<SexTranslation> b)
        {
            b.HasKey(x => new { x.SexId, x.LanguageId });
        }
    }

    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> b)
        {
            b.HasOne(x => x.Sex).WithMany(x => x.Persons).HasForeignKey(x => x.SexId).OnDelete(DeleteBehavior.Restrict);
            b.HasOne(x => x.MilitaryServiceStatus).WithMany(x => x.Persons).HasForeignKey(x => x.MilitaryServiceStatusId).OnDelete(DeleteBehavior.Restrict);
            b.HasOne(x => x.MilitaryServiceLocation).WithMany(x => x.Persons).HasForeignKey(x => x.MilitaryServiceLocationId).OnDelete(DeleteBehavior.Restrict);
            b.HasOne(x => x.InsuranceType).WithMany(x => x.Persons).HasForeignKey(x => x.InsuranceTypeId).OnDelete(DeleteBehavior.Restrict);
            b.HasOne(x => x.MaritalStatus).WithMany(x => x.Persons).HasForeignKey(x => x.MaritalStatusId).OnDelete(DeleteBehavior.Restrict);
            b.HasOne(x => x.BirthCertificateSeriesLetter).WithMany(x => x.Persons).HasForeignKey(x => x.BirthCertificateSeriesLetterId).OnDelete(DeleteBehavior.Restrict);
            b.HasOne(x => x.Religion).WithMany(x => x.Persons).HasForeignKey(x => x.ReligionId).OnDelete(DeleteBehavior.Restrict);
            b.HasMany(x => x.Translations).WithOne(x => x.Person).HasForeignKey(x => x.PersonId).OnDelete(DeleteBehavior.Cascade);
            b.HasMany(x => x.Emails).WithOne(x => x.Person).HasForeignKey(x => x.PersonId).OnDelete(DeleteBehavior.Cascade);
            b.HasMany(x => x.Phones).WithOne(x => x.Person).HasForeignKey(x => x.PersonId).OnDelete(DeleteBehavior.Cascade);
            b.HasMany(x => x.Addresses).WithOne(x => x.Person).HasForeignKey(x => x.PersonId).OnDelete(DeleteBehavior.Cascade);
            b.HasMany(x => x.Employments).WithOne(x => x.Person).HasForeignKey(x => x.PersonId).OnDelete(DeleteBehavior.Cascade);
            b.HasMany(x => x.RelationshipsAsPerson).WithOne(x => x.Person).HasForeignKey(x => x.PersonId).OnDelete(DeleteBehavior.NoAction);
            b.HasMany(x => x.RelationshipsAsRelatedPerson).WithOne(x => x.RelatedPerson).HasForeignKey(x => x.RelatedPersonId).OnDelete(DeleteBehavior.NoAction);
            b.HasMany(x => x.Nationalities).WithOne(x => x.Person).HasForeignKey(x => x.PersonId).OnDelete(DeleteBehavior.Cascade);
            b.HasMany(x => x.Documents).WithOne(x => x.Person).HasForeignKey(x => x.PersonId).OnDelete(DeleteBehavior.Cascade);
            b.HasMany(x => x.Educations).WithOne(x => x.Person).HasForeignKey(x => x.PersonId).OnDelete(DeleteBehavior.Cascade);

        }
    }

    public class TranslationConfiguration : IEntityTypeConfiguration<Translation>
    {
        public void Configure(EntityTypeBuilder<Translation> b)
        {
            b.HasKey(x => new { x.PersonId, x.LanguageId });
            b.ToTable("Translation", "dbo", tb => tb.HasTrigger("Translation_Trigger"));

        }
    }

    public class EmailLabelConfiguration : IEntityTypeConfiguration<EmailLabel>
    {
        public void Configure(EntityTypeBuilder<EmailLabel> b)
        {
            b.HasMany(x => x.Translations).WithOne(x => x.EmailLabel).HasForeignKey(x => x.EmailLabelId).OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class EmailLabelTranslationConfiguration : IEntityTypeConfiguration<EmailLabelTranslation>
    {
        public void Configure(EntityTypeBuilder<EmailLabelTranslation> b)
        {
            b.HasKey(x => new { x.EmailLabelId, x.LanguageId });
        }
    }

    public class EmailConfiguration : IEntityTypeConfiguration<Email>
    {
        public void Configure(EntityTypeBuilder<Email> b)
        {
            b.HasOne(x => x.Label).WithMany(x => x.Emails).HasForeignKey(x => x.LabelId).OnDelete(DeleteBehavior.Restrict);

        }
    }

    public class PhoneLabelConfiguration : IEntityTypeConfiguration<PhoneLabel>
    {
        public void Configure(EntityTypeBuilder<PhoneLabel> b)
        {
            b.HasMany(x => x.Translations).WithOne(x => x.PhoneLabel).HasForeignKey(x => x.PhoneLabelId).OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class PhoneLabelTranslationConfiguration : IEntityTypeConfiguration<PhoneLabelTranslation>
    {
        public void Configure(EntityTypeBuilder<PhoneLabelTranslation> b)
        {
            b.HasKey(x => new { x.PhoneLabelId, x.LanguageId });
        }
    }

    public class PhoneConfiguration : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> b)
        {
            b.HasOne(x => x.Label).WithMany(x => x.Phones).HasForeignKey(x => x.LabelId).OnDelete(DeleteBehavior.Restrict);

        }
    }

    public class AddressLabelConfiguration : IEntityTypeConfiguration<AddressLabel>
    {
        public void Configure(EntityTypeBuilder<AddressLabel> b)
        {
            b.HasMany(x => x.Translations).WithOne(x => x.AddressLabel).HasForeignKey(x => x.AddressLabelId).OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class AddressLabelTranslationConfiguration : IEntityTypeConfiguration<AddressLabelTranslation>
    {
        public void Configure(EntityTypeBuilder<AddressLabelTranslation> b)
        {
            b.HasKey(x => new { x.AddressLabelId, x.LanguageId });
        }
    }

    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> b)
        {
            b.HasOne(x => x.Label).WithMany(x => x.Addresses).HasForeignKey(x => x.LabelId).OnDelete(DeleteBehavior.Restrict);
            b.HasMany(x => x.Translations).WithOne(x => x.Address).HasForeignKey(x => x.AddressId).OnDelete(DeleteBehavior.Cascade);

        }
    }

    public class AddressTranslationConfiguration : IEntityTypeConfiguration<AddressTranslation>
    {
        public void Configure(EntityTypeBuilder<AddressTranslation> b)
        {
            b.HasKey(x => new { x.AddressId, x.LanguageId });
        }
    }

    public class RelationshipTypeConfiguration : IEntityTypeConfiguration<RelationshipType>
    {
        public void Configure(EntityTypeBuilder<RelationshipType> b)
        {
            b.HasMany(x => x.Translations).WithOne(x => x.RelationshipType).HasForeignKey(x => x.RelationshipTypeId).OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class RelationshipTypeTranslationConfiguration : IEntityTypeConfiguration<RelationshipTypeTranslation>
    {
        public void Configure(EntityTypeBuilder<RelationshipTypeTranslation> b)
        {
            b.HasKey(x => new { x.RelationshipTypeId, x.LanguageId });
        }
    }

    public class RelationshipConfiguration : IEntityTypeConfiguration<Relationship>
    {
        public void Configure(EntityTypeBuilder<Relationship> b)
        {
            b.HasOne(x => x.RelationshipType).WithMany(x => x.Relationships).HasForeignKey(x => x.RelationshipTypeId).OnDelete(DeleteBehavior.Restrict);

        }
    }

    public class MilitaryServiceLocationConfiguration : IEntityTypeConfiguration<MilitaryServiceLocation>
    {
        public void Configure(EntityTypeBuilder<MilitaryServiceLocation> b)
        {
            b.HasMany(x => x.Translations).WithOne(x => x.MilitaryServiceLocation).HasForeignKey(x => x.MilitaryServiceLocationId).OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class MilitaryServiceLocationTranslationConfiguration : IEntityTypeConfiguration<MilitaryServiceLocationTranslation>
    {
        public void Configure(EntityTypeBuilder<MilitaryServiceLocationTranslation> b)
        {
            b.HasKey(x => new { x.MilitaryServiceLocationId, x.LanguageId });
        }
    }

    public class MilitaryServiceStatusConfiguration : IEntityTypeConfiguration<MilitaryServiceStatus>
    {
        public void Configure(EntityTypeBuilder<MilitaryServiceStatus> b)
        {
            b.HasMany(x => x.Translations).WithOne(x => x.MilitaryServiceStatus).HasForeignKey(x => x.MilitaryServiceStatusId).OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class MilitaryServiceStatusTranslationConfiguration : IEntityTypeConfiguration<MilitaryServiceStatusTranslation>
    {
        public void Configure(EntityTypeBuilder<MilitaryServiceStatusTranslation> b)
        {
            b.HasKey(x => new { x.MilitaryServiceStatusId, x.LanguageId });
        }
    }

    public class MaritalStatusConfiguration : IEntityTypeConfiguration<MaritalStatus>
    {
        public void Configure(EntityTypeBuilder<MaritalStatus> b)
        {
            b.HasMany(x => x.Translations).WithOne(x => x.MaritalStatus).HasForeignKey(x => x.MaritalStatusId).OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class MaritalStatusTranslationConfiguration : IEntityTypeConfiguration<MaritalStatusTranslation>
    {
        public void Configure(EntityTypeBuilder<MaritalStatusTranslation> b)
        {
            b.HasKey(x => new { x.MaritalStatusId, x.LanguageId });
        }
    }

    public class InsuranceTypeConfiguration : IEntityTypeConfiguration<InsuranceType>
    {
        public void Configure(EntityTypeBuilder<InsuranceType> b)
        {
            b.HasMany(x => x.Translations).WithOne(x => x.InsuranceType).HasForeignKey(x => x.InsuranceTypeId).OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class InsuranceTypeTranslationConfiguration : IEntityTypeConfiguration<InsuranceTypeTranslation>
    {
        public void Configure(EntityTypeBuilder<InsuranceTypeTranslation> b)
        {
            b.HasKey(x => new { x.InsuranceTypeId, x.LanguageId });
        }
    }

    public class ContractTypeConfiguration : IEntityTypeConfiguration<ContractType>
    {
        public void Configure(EntityTypeBuilder<ContractType> b)
        {
            b.HasMany(x => x.Translations).WithOne(x => x.ContractType).HasForeignKey(x => x.ContractTypeId).OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class ContractTypeTranslationConfiguration : IEntityTypeConfiguration<ContractTypeTranslation>
    {
        public void Configure(EntityTypeBuilder<ContractTypeTranslation> b)
        {
            b.HasKey(x => new { x.ContractTypeId, x.LanguageId });
        }
    }

    public class EmploymentActivityFieldConfiguration : IEntityTypeConfiguration<EmploymentActivityField>
    {
        public void Configure(EntityTypeBuilder<EmploymentActivityField> b)
        {
            b.HasMany(x => x.Translations).WithOne(x => x.EmploymentActivityField).HasForeignKey(x => x.EmploymentActivityFieldId).OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class EmploymentActivityFieldTranslationConfiguration : IEntityTypeConfiguration<EmploymentActivityFieldTranslation>
    {
        public void Configure(EntityTypeBuilder<EmploymentActivityFieldTranslation> b)
        {
            b.HasKey(x => new { x.EmploymentActivityFieldId, x.LanguageId });
        }
    }

    public class EmploymentActivityUnitConfiguration : IEntityTypeConfiguration<EmploymentActivityUnit>
    {
        public void Configure(EntityTypeBuilder<EmploymentActivityUnit> b)
        {
            b.HasMany(x => x.Translations).WithOne(x => x.EmploymentActivityUnit).HasForeignKey(x => x.EmploymentActivityUnitId).OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class EmploymentActivityUnitTranslationConfiguration : IEntityTypeConfiguration<EmploymentActivityUnitTranslation>
    {
        public void Configure(EntityTypeBuilder<EmploymentActivityUnitTranslation> b)
        {
            b.HasKey(x => new { x.EmploymentActivityUnitId, x.LanguageId });
        }
    }

    public class EmploymentPositionConfiguration : IEntityTypeConfiguration<EmploymentPosition>
    {
        public void Configure(EntityTypeBuilder<EmploymentPosition> b)
        {
            b.HasMany(x => x.Translations).WithOne(x => x.EmploymentPosition).HasForeignKey(x => x.EmploymentPositionId).OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class EmploymentPositionTranslationConfiguration : IEntityTypeConfiguration<EmploymentPositionTranslation>
    {
        public void Configure(EntityTypeBuilder<EmploymentPositionTranslation> b)
        {
            b.HasKey(x => new { x.EmploymentPositionId, x.LanguageId });
        }
    }

    public class DocumentTypeConfiguration : IEntityTypeConfiguration<DocumentType>
    {
        public void Configure(EntityTypeBuilder<DocumentType> b)
        {
            b.HasMany(x => x.Translations).WithOne(x => x.DocumentType).HasForeignKey(x => x.DocumentTypeId).OnDelete(DeleteBehavior.Cascade);
            b.HasMany(x => x.Documents).WithOne(x => x.DocumentType).HasForeignKey(x => x.DocumentTypeId).OnDelete(DeleteBehavior.Restrict);
            b.Property(x => x.IsActive).HasDefaultValue(true);

        }
    }

    public class DocumentTypeTranslationConfiguration : IEntityTypeConfiguration<DocumentTypeTranslation>
    {
        public void Configure(EntityTypeBuilder<DocumentTypeTranslation> b)
        {
            b.HasKey(x => new { x.DocumentTypeId, x.LanguageId });
        }
    }

    public class DocumentConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> b)
        {
            b.HasIndex(x => x.PersonId);

        }
    }

    public class NationalityConfiguration : IEntityTypeConfiguration<Nationality>
    {
        public void Configure(EntityTypeBuilder<Nationality> b) { }
    }

    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> b) { }
    }

    public class EmploymentConfiguration : IEntityTypeConfiguration<Employment>
    {
        public void Configure(EntityTypeBuilder<Employment> b)
        {
            b.HasMany(x => x.EmploymentDocuments).WithOne(x => x.Employment).HasForeignKey(x => x.EmploymentId).OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class EmploymentDocumentConfiguration : IEntityTypeConfiguration<EmploymentDocument>
    {
        public void Configure(EntityTypeBuilder<EmploymentDocument> b)
        {
            b.HasIndex(x => x.EmploymentId);
            b.HasOne(x => x.EmploymentDocumentType)
                .WithMany(x => x.EmploymentDocuments)
                .HasForeignKey(x => x.EmploymentDocumentTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

    public class EmploymentDocumentTypeConfiguration : IEntityTypeConfiguration<EmploymentDocumentType>
    {
        public void Configure(EntityTypeBuilder<EmploymentDocumentType> b)
        {
            b.HasMany(x => x.Translations).WithOne(x => x.EmploymentDocumentType).HasForeignKey(x => x.EmploymentDocumentTypeId).OnDelete(DeleteBehavior.Cascade);
            b.Property(x => x.IsActive).HasDefaultValue(true);
        }
    }

    public class EmploymentDocumentTypeTranslationConfiguration : IEntityTypeConfiguration<EmploymentDocumentTypeTranslation>
    {
        public void Configure(EntityTypeBuilder<EmploymentDocumentTypeTranslation> b)
        {
            b.HasKey(x => new { x.EmploymentDocumentTypeId, x.LanguageId });
        }
    }

    public class EducationLevelConfiguration : IEntityTypeConfiguration<EducationLevel>
    {
        public void Configure(EntityTypeBuilder<EducationLevel> b)
        {
            b.HasMany(x => x.Translations).WithOne(x => x.EducationLevel).HasForeignKey(x => x.EducationLevelId).OnDelete(DeleteBehavior.Cascade);
            b.HasMany(x => x.Educations).WithOne(x => x.EducationLevel).HasForeignKey(x => x.EducationLevelId).OnDelete(DeleteBehavior.Restrict);
            b.Property(x => x.IsActive).HasDefaultValue(true);
        }
    }

    public class EducationLevelTranslationConfiguration : IEntityTypeConfiguration<EducationLevelTranslation>
    {
        public void Configure(EntityTypeBuilder<EducationLevelTranslation> b)
        {
            b.HasKey(x => new { x.EducationLevelId, x.LanguageId });
        }
    }

    public class FieldOfStudyConfiguration : IEntityTypeConfiguration<FieldOfStudy>
    {
        public void Configure(EntityTypeBuilder<FieldOfStudy> b)
        {
            b.HasMany(x => x.Translations).WithOne(x => x.FieldOfStudy).HasForeignKey(x => x.FieldOfStudyId).OnDelete(DeleteBehavior.Cascade);
            b.HasMany(x => x.Educations).WithOne(x => x.FieldOfStudy).HasForeignKey(x => x.FieldOfStudyId).OnDelete(DeleteBehavior.Restrict);
            b.Property(x => x.IsActive).HasDefaultValue(true);
        }
    }

    public class FieldOfStudyTranslationConfiguration : IEntityTypeConfiguration<FieldOfStudyTranslation>
    {
        public void Configure(EntityTypeBuilder<FieldOfStudyTranslation> b)
        {
            b.HasKey(x => new { x.FieldOfStudyId, x.LanguageId });
        }
    }

    public class InstitutionConfiguration : IEntityTypeConfiguration<Institution>
    {
        public void Configure(EntityTypeBuilder<Institution> b)
        {
            b.HasMany(x => x.Translations).WithOne(x => x.Institution).HasForeignKey(x => x.InstitutionId).OnDelete(DeleteBehavior.Cascade);
            b.HasMany(x => x.Educations).WithOne(x => x.Institution).HasForeignKey(x => x.InstitutionId).OnDelete(DeleteBehavior.Restrict);
            b.Property(x => x.IsActive).HasDefaultValue(true);
            b.HasIndex(x => x.Code).IsUnique();
        }
    }

    public class InstitutionTranslationConfiguration : IEntityTypeConfiguration<InstitutionTranslation>
    {
        public void Configure(EntityTypeBuilder<InstitutionTranslation> b)
        {
            b.HasKey(x => new { x.InstitutionId, x.LanguageId });
        }
    }

    public class EducationConfiguration : IEntityTypeConfiguration<Education>
    {
        public void Configure(EntityTypeBuilder<Education> b)
        {
            b.HasIndex(x => x.PersonId);
            b.HasMany(x => x.EducationDocuments).WithOne(x => x.Education).HasForeignKey(x => x.EducationId).OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class EducationDocumentConfiguration : IEntityTypeConfiguration<EducationDocument>
    {
        public void Configure(EntityTypeBuilder<EducationDocument> b)
        {
            b.HasIndex(x => x.EducationId);
            b.HasOne(x => x.EducationDocumentType)
                .WithMany(x => x.EducationDocuments)
                .HasForeignKey(x => x.EducationDocumentTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

    public class EducationDocumentTypeConfiguration : IEntityTypeConfiguration<EducationDocumentType>
    {
        public void Configure(EntityTypeBuilder<EducationDocumentType> b)
        {
            b.HasMany(x => x.Translations).WithOne(x => x.EducationDocumentType).HasForeignKey(x => x.EducationDocumentTypeId).OnDelete(DeleteBehavior.Cascade);
            b.Property(x => x.IsActive).HasDefaultValue(true);
        }
    }

    public class EducationDocumentTypeTranslationConfiguration : IEntityTypeConfiguration<EducationDocumentTypeTranslation>
    {
        public void Configure(EntityTypeBuilder<EducationDocumentTypeTranslation> b)
        {
            b.HasKey(x => new { x.EducationDocumentTypeId, x.LanguageId });
        }
    }

    public class ProfessionalTrainingConfiguration : IEntityTypeConfiguration<ProfessionalTraining>
    {
        public void Configure(EntityTypeBuilder<ProfessionalTraining> b)
        {
            b.HasIndex(x => x.PersonId);
            b.HasMany(x => x.ProfessionalTrainingDocuments).WithOne(x => x.ProfessionalTraining)
                .HasForeignKey(x => x.ProfessionalTrainingId).OnDelete(DeleteBehavior.Cascade);
            b.HasOne(x => x.ProfessionalTrainingType).WithMany(x => x.ProfessionalTrainings)
                .HasForeignKey(x => x.ProfessionalTrainingTypeId).OnDelete(DeleteBehavior.Restrict);
            b.HasOne(x => x.ProfessionalTrainingCertificateIssuer).WithMany(x => x.ProfessionalTrainings)
                .HasForeignKey(x => x.ProfessionalTrainingCertificateIssuerId).OnDelete(DeleteBehavior.Restrict);
        }
    }

    public class ProfessionalTrainingDocumentConfiguration : IEntityTypeConfiguration<ProfessionalTrainingDocument>
    {
        public void Configure(EntityTypeBuilder<ProfessionalTrainingDocument> b)
        {
            b.HasIndex(x => x.ProfessionalTrainingId);
            b.HasOne(x => x.ProfessionalTrainingDocumentType).WithMany(x => x.ProfessionalTrainingDocuments)
                .HasForeignKey(x => x.ProfessionalTrainingDocumentTypeId).OnDelete(DeleteBehavior.Restrict);
        }
    }

    public class ProfessionalTrainingTypeConfiguration : IEntityTypeConfiguration<ProfessionalTrainingType>
    {
        public void Configure(EntityTypeBuilder<ProfessionalTrainingType> b)
        {
            b.HasMany(x => x.Translations).WithOne(x => x.ProfessionalTrainingType)
                .HasForeignKey(x => x.ProfessionalTrainingTypeId).OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class ProfessionalTrainingTypeTranslationConfiguration : IEntityTypeConfiguration<ProfessionalTrainingTypeTranslation>
    {
        public void Configure(EntityTypeBuilder<ProfessionalTrainingTypeTranslation> b)
            => b.HasKey(x => new { x.ProfessionalTrainingTypeId, x.LanguageId });
    }

    public class ProfessionalTrainingCertificateIssuerConfiguration : IEntityTypeConfiguration<ProfessionalTrainingCertificateIssuer>
    {
        public void Configure(EntityTypeBuilder<ProfessionalTrainingCertificateIssuer> b)
        {
            b.HasMany(x => x.Translations).WithOne(x => x.ProfessionalTrainingCertificateIssuer)
                .HasForeignKey(x => x.ProfessionalTrainingCertificateIssuerId).OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class ProfessionalTrainingCertificateIssuerTranslationConfiguration : IEntityTypeConfiguration<ProfessionalTrainingCertificateIssuerTranslation>
    {
        public void Configure(EntityTypeBuilder<ProfessionalTrainingCertificateIssuerTranslation> b)
            => b.HasKey(x => new { x.ProfessionalTrainingCertificateIssuerId, x.LanguageId });
    }

    public class ProfessionalTrainingDocumentTypeConfiguration : IEntityTypeConfiguration<ProfessionalTrainingDocumentType>
    {
        public void Configure(EntityTypeBuilder<ProfessionalTrainingDocumentType> b)
        {
            b.HasMany(x => x.Translations).WithOne(x => x.ProfessionalTrainingDocumentType)
                .HasForeignKey(x => x.ProfessionalTrainingDocumentTypeId).OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class ProfessionalTrainingDocumentTypeTranslationConfiguration : IEntityTypeConfiguration<ProfessionalTrainingDocumentTypeTranslation>
    {
        public void Configure(EntityTypeBuilder<ProfessionalTrainingDocumentTypeTranslation> b)
            => b.HasKey(x => new { x.ProfessionalTrainingDocumentTypeId, x.LanguageId });
    }
}
