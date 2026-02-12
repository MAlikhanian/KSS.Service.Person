using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KSS.Entity
{
    [Table("Person", Schema = "dbo")]
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public byte SexId { get; set; }
        public short PreferredLanguageId { get; set; }
        [Required]
        [MaxLength(20)]
        public string NationalId { get; set; } = string.Empty;
        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }
        public short BirthCountryId { get; set; }
        public short BirthRegionId { get; set; }
        public int BirthCityId { get; set; }
        public short NationalityCountryId { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [ForeignKey(nameof(SexId))]
        public Sex Sex { get; set; } = null!;
        public ICollection<PersonTranslation> Translations { get; set; } = new List<PersonTranslation>();
        public ICollection<Email> Emails { get; set; } = new List<Email>();
        public ICollection<Phone> Phones { get; set; } = new List<Phone>();
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
        public ICollection<Employment> Employments { get; set; } = new List<Employment>();
        public ICollection<Relationship> RelationshipsAsPerson { get; set; } = new List<Relationship>();
        public ICollection<Relationship> RelationshipsAsRelatedPerson { get; set; } = new List<Relationship>();
    }
}

