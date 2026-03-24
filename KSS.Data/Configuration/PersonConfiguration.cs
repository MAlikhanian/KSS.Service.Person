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
        }
    }

    public class PersonTranslationConfiguration : IEntityTypeConfiguration<PersonTranslation>
    {
        public void Configure(EntityTypeBuilder<PersonTranslation> b)
        {
            b.HasKey(x => new { x.PersonId, x.LanguageId });
            b.ToTable("PersonTranslation", "dbo", tb => tb.HasTrigger("PersonTranslation_Trigger"));
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

    public class JobCategoryConfiguration : IEntityTypeConfiguration<JobCategory>
    {
        public void Configure(EntityTypeBuilder<JobCategory> b)
        {
            b.HasMany(x => x.Translations).WithOne(x => x.JobCategory).HasForeignKey(x => x.JobCategoryId).OnDelete(DeleteBehavior.Cascade);
            b.HasMany(x => x.JobDepartments).WithOne(x => x.JobCategory).HasForeignKey(x => x.JobCategoryId).OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class JobCategoryTranslationConfiguration : IEntityTypeConfiguration<JobCategoryTranslation>
    {
        public void Configure(EntityTypeBuilder<JobCategoryTranslation> b)
        {
            b.HasKey(x => new { x.JobCategoryId, x.LanguageId });
        }
    }

    public class JobDepartmentConfiguration : IEntityTypeConfiguration<JobDepartment>
    {
        public void Configure(EntityTypeBuilder<JobDepartment> b)
        {
            b.HasMany(x => x.Translations).WithOne(x => x.JobDepartment).HasForeignKey(x => x.JobDepartmentId).OnDelete(DeleteBehavior.Cascade);
            b.HasMany(x => x.JobTitles).WithOne(x => x.JobDepartment).HasForeignKey(x => x.JobDepartmentId).OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class JobDepartmentTranslationConfiguration : IEntityTypeConfiguration<JobDepartmentTranslation>
    {
        public void Configure(EntityTypeBuilder<JobDepartmentTranslation> b)
        {
            b.HasKey(x => new { x.JobDepartmentId, x.LanguageId });
        }
    }

    public class JobTitleConfiguration : IEntityTypeConfiguration<JobTitle>
    {
        public void Configure(EntityTypeBuilder<JobTitle> b)
        {
            b.HasMany(x => x.Translations).WithOne(x => x.JobTitle).HasForeignKey(x => x.JobTitleId).OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class JobTitleTranslationConfiguration : IEntityTypeConfiguration<JobTitleTranslation>
    {
        public void Configure(EntityTypeBuilder<JobTitleTranslation> b)
        {
            b.HasKey(x => new { x.JobTitleId, x.LanguageId });
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

    public class BusinessSectorConfiguration : IEntityTypeConfiguration<BusinessSector>
    {
        public void Configure(EntityTypeBuilder<BusinessSector> b)
        {
            b.HasMany(x => x.Translations).WithOne(x => x.BusinessSector).HasForeignKey(x => x.BusinessSectorId).OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class BusinessSectorTranslationConfiguration : IEntityTypeConfiguration<BusinessSectorTranslation>
    {
        public void Configure(EntityTypeBuilder<BusinessSectorTranslation> b)
        {
            b.HasKey(x => new { x.BusinessSectorId, x.LanguageId });
        }
    }

    public class BusinessUnitConfiguration : IEntityTypeConfiguration<BusinessUnit>
    {
        public void Configure(EntityTypeBuilder<BusinessUnit> b)
        {
            b.HasMany(x => x.Translations).WithOne(x => x.BusinessUnit).HasForeignKey(x => x.BusinessUnitId).OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class BusinessUnitTranslationConfiguration : IEntityTypeConfiguration<BusinessUnitTranslation>
    {
        public void Configure(EntityTypeBuilder<BusinessUnitTranslation> b)
        {
            b.HasKey(x => new { x.BusinessUnitId, x.LanguageId });
        }
    }

    public class JobPositionConfiguration : IEntityTypeConfiguration<JobPosition>
    {
        public void Configure(EntityTypeBuilder<JobPosition> b)
        {
            b.HasMany(x => x.Translations).WithOne(x => x.JobPosition).HasForeignKey(x => x.JobPositionId).OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class JobPositionTranslationConfiguration : IEntityTypeConfiguration<JobPositionTranslation>
    {
        public void Configure(EntityTypeBuilder<JobPositionTranslation> b)
        {
            b.HasKey(x => new { x.JobPositionId, x.LanguageId });
        }
    }
}
