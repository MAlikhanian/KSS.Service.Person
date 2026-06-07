using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KSS.Entity
{
    [Table("MaritalStatusTranslation", Schema = "dbo")]
    public class MaritalStatusTranslation
    {
        public byte MaritalStatusId { get; set; }
        public short LanguageId { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; } = string.Empty;
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        [ForeignKey(nameof(MaritalStatusId))]
        public MaritalStatus MaritalStatus { get; set; } = null!;
    }
}
