using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KSS.Entity
{
    [Table("Person", Schema = "dbo")]
    public class Person
    {
        [Key]
        public Guid Id { get; set; }
        public byte SexId { get; set; }
        public short PreferredLanguageId { get; set; }
        [Required]
        [MaxLength(20)]
        [Unicode(false)]
        public string NationalId { get; set; } = string.Empty;
        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }
        public short BirthCountryId { get; set; }
        public short BirthRegionId { get; set; }
        public int BirthCityId { get; set; }
        [MaxLength(20)]
        [Unicode(false)]
        public string? BirthCertificateNumber { get; set; }
        [MaxLength(2)]
        [Unicode(false)]
        public string? BirthCertificateSeriesNumber { get; set; }
        public byte? BirthCertificateSeriesLetterId { get; set; }
        [MaxLength(6)]
        [Unicode(false)]
        public string? BirthCertificateSerial { get; set; }
        public short BirthCertificateIssueCountryId { get; set; }
        public short BirthCertificateIssueRegionId { get; set; }
        public int BirthCertificateIssueCityId { get; set; }
        public byte MaritalStatusId { get; set; }
        public short? ReligionId { get; set; }
        [MaxLength(20)]
        [Unicode(false)]
        public string? PassportNumber { get; set; }
        public byte? MilitaryServiceStatusId { get; set; }
        public short? MilitaryServiceLocationId { get; set; }
        public byte? InsuranceTypeId { get; set; }
        [MaxLength(30)]
        [Unicode(false)]
        public string? InsuranceNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [ForeignKey(nameof(SexId))]
        public Sex Sex { get; set; } = null!;
        [ForeignKey(nameof(MilitaryServiceStatusId))]
        public MilitaryServiceStatus MilitaryServiceStatus { get; set; } = null!;
        [ForeignKey(nameof(MilitaryServiceLocationId))]
        public MilitaryServiceLocation? MilitaryServiceLocation { get; set; }
        [ForeignKey(nameof(InsuranceTypeId))]
        public InsuranceType InsuranceType { get; set; } = null!;
        [ForeignKey(nameof(MaritalStatusId))]
        public MaritalStatus MaritalStatus { get; set; } = null!;
        [ForeignKey(nameof(BirthCertificateSeriesLetterId))]
        public BirthCertificateSeriesLetter? BirthCertificateSeriesLetter { get; set; }
        [ForeignKey(nameof(ReligionId))]
        public Religion Religion { get; set; } = null!;
        public ICollection<PersonTranslation> Translations { get; set; } = new List<PersonTranslation>();
        public ICollection<Email> Emails { get; set; } = new List<Email>();
        public ICollection<Phone> Phones { get; set; } = new List<Phone>();
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
        public ICollection<Employment> Employments { get; set; } = new List<Employment>();
        public ICollection<Relationship> RelationshipsAsPerson { get; set; } = new List<Relationship>();
        public ICollection<Relationship> RelationshipsAsRelatedPerson { get; set; } = new List<Relationship>();
        public ICollection<PersonNationality> Nationalities { get; set; } = new List<PersonNationality>();
        public ICollection<PersonStatus> Statuses { get; set; } = new List<PersonStatus>();
    }
}

