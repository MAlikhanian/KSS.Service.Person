using Microsoft.EntityFrameworkCore;
using KSS.Entity;

namespace KSS.Data.DbContexts
{
    public partial class MainDbContext
    {
        public DbSet<Sex> Sexes { get; set; }
        public DbSet<SexTranslation> SexTranslations { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Translation> Translations { get; set; }
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
        public DbSet<Employment> Employments { get; set; }
        public DbSet<RelationshipType> RelationshipTypes { get; set; }
        public DbSet<RelationshipTypeTranslation> RelationshipTypeTranslations { get; set; }
        public DbSet<Relationship> Relationships { get; set; }
        public DbSet<MaritalStatus> MaritalStatuses { get; set; }
        public DbSet<MaritalStatusTranslation> MaritalStatusTranslations { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<Religion> Religions { get; set; }
        public DbSet<ReligionTranslation> ReligionTranslations { get; set; }
        public DbSet<BirthCertificateSeriesLetter> BirthCertificateSeriesLetters { get; set; }
        public DbSet<BirthCertificateSeriesLetterTranslation> BirthCertificateSeriesLetterTranslations { get; set; }
        public DbSet<MilitaryServiceLocation> MilitaryServiceLocations { get; set; }
        public DbSet<MilitaryServiceLocationTranslation> MilitaryServiceLocationTranslations { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<ContractType> ContractTypes { get; set; }
        public DbSet<ContractTypeTranslation> ContractTypeTranslations { get; set; }
        public DbSet<EmploymentActivityField> EmploymentActivityFields { get; set; }
        public DbSet<EmploymentActivityFieldTranslation> EmploymentActivityFieldTranslations { get; set; }
        public DbSet<EmploymentActivityUnit> EmploymentActivityUnits { get; set; }
        public DbSet<EmploymentActivityUnitTranslation> EmploymentActivityUnitTranslations { get; set; }
        public DbSet<EmploymentPosition> EmploymentPositions { get; set; }
        public DbSet<EmploymentPositionTranslation> EmploymentPositionTranslations { get; set; }
    }
}
