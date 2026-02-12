using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KSS.Entity
{
    [Table("RelationshipType", Schema = "dbo")]
    public class RelationshipType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Code { get; set; } = string.Empty;

        public ICollection<RelationshipTypeTranslation> Translations { get; set; } = new List<RelationshipTypeTranslation>();
        public ICollection<Relationship> Relationships { get; set; } = new List<Relationship>();
    }
}

