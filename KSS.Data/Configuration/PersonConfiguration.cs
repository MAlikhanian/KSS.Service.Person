using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KSS.Entity;

namespace KSS.Data.Configuration
{
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
            b.HasMany(x => x.Translations).WithOne(x => x.Person).HasForeignKey(x => x.PersonId).OnDelete(DeleteBehavior.Cascade);
            b.HasMany(x => x.Emails).WithOne(x => x.Person).HasForeignKey(x => x.PersonId).OnDelete(DeleteBehavior.Cascade);
            b.HasMany(x => x.Phones).WithOne(x => x.Person).HasForeignKey(x => x.PersonId).OnDelete(DeleteBehavior.Cascade);
            b.HasMany(x => x.Addresses).WithOne(x => x.Person).HasForeignKey(x => x.PersonId).OnDelete(DeleteBehavior.Cascade);
            b.HasMany(x => x.Employments).WithOne(x => x.Person).HasForeignKey(x => x.PersonId).OnDelete(DeleteBehavior.Cascade);
            b.HasMany(x => x.RelationshipsAsPerson).WithOne(x => x.Person).HasForeignKey(x => x.PersonId).OnDelete(DeleteBehavior.NoAction);
            b.HasMany(x => x.RelationshipsAsRelatedPerson).WithOne(x => x.RelatedPerson).HasForeignKey(x => x.RelatedPersonId).OnDelete(DeleteBehavior.NoAction);
        }
    }

    public class PersonTranslationConfiguration : IEntityTypeConfiguration<PersonTranslation>
    {
        public void Configure(EntityTypeBuilder<PersonTranslation> b)
        {
            b.HasKey(x => new { x.PersonId, x.LanguageId });
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
            b.HasMany(x => x.Employments).WithOne(x => x.JobTitle).HasForeignKey(x => x.JobTitleId).OnDelete(DeleteBehavior.Restrict);
        }
    }

    public class JobTitleTranslationConfiguration : IEntityTypeConfiguration<JobTitleTranslation>
    {
        public void Configure(EntityTypeBuilder<JobTitleTranslation> b)
        {
            b.HasKey(x => new { x.JobTitleId, x.LanguageId });
        }
    }

    public class EmploymentConfiguration : IEntityTypeConfiguration<Employment>
    {
        public void Configure(EntityTypeBuilder<Employment> b)
        {
            b.HasOne(x => x.JobTitle).WithMany(x => x.Employments).HasForeignKey(x => x.JobTitleId).OnDelete(DeleteBehavior.Restrict);
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
}
