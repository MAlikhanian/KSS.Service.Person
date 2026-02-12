using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KSS.Entity
{
    [Table("RelationshipTypeTranslation", Schema = "dbo")]
    public class RelationshipTypeTranslation
    {
        public byte RelationshipTypeId { get; set; }
        public short LanguageId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [ForeignKey(nameof(RelationshipTypeId))]
        public RelationshipType RelationshipType { get; set; } = null!;
    }
}

