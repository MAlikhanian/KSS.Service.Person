using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KSS.Entity
{
    [Table("Address", Schema = "dbo")]
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public byte LabelId { get; set; }
        public short CountryId { get; set; }
        public short RegionId { get; set; }
        public int CityId { get; set; }
        [Required]
        [MaxLength(10)]
        public string PostalCode { get; set; } = string.Empty;
        [Column(TypeName = "decimal(9, 6)")]
        public decimal? Latitude { get; set; }
        [Column(TypeName = "decimal(9, 6)")]
        public decimal? Longitude { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsVerified { get; set; }
        public DateTime? VerifiedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [ForeignKey(nameof(PersonId))]
        public Person Person { get; set; } = null!;
        [ForeignKey(nameof(LabelId))]
        public AddressLabel Label { get; set; } = null!;
        public ICollection<AddressTranslation> Translations { get; set; } = new List<AddressTranslation>();
    }
}

