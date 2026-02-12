using Microsoft.EntityFrameworkCore;
using KSS.Entity;

namespace KSS.Data.DbContexts
{
    public partial class MainDbContext
    {
        public DbSet<Sex> Sexes { get; set; }
        public DbSet<SexTranslation> SexTranslations { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonTranslation> PersonTranslations { get; set; }
        public DbSet<EmailLabel> EmailLabels { get; set; }
        public DbSet<EmailLabelTranslation> EmailLabelTranslations { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<PhoneLabel> PhoneLabels { get; set; }
        public DbSet<PhoneLabelTranslation> PhoneLabelTranslations { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<AddressLabel> AddressLabels { get; set; }
        public DbSet<AddressLabelTranslation> AddressLabelTranslations { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<AddressTranslation> AddressTranslations { get; set; }
        public DbSet<JobCategory> JobCategories { get; set; }
        public DbSet<JobCategoryTranslation> JobCategoryTranslations { get; set; }
        public DbSet<JobDepartment> JobDepartments { get; set; }
        public DbSet<JobDepartmentTranslation> JobDepartmentTranslations { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }
        public DbSet<JobTitleTranslation> JobTitleTranslations { get; set; }
        public DbSet<Employment> Employments { get; set; }
        public DbSet<RelationshipType> RelationshipTypes { get; set; }
        public DbSet<RelationshipTypeTranslation> RelationshipTypeTranslations { get; set; }
        public DbSet<Relationship> Relationships { get; set; }
    }
}
