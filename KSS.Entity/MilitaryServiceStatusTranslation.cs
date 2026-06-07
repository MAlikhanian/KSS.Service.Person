using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KSS.Entity
{
    [Table("MilitaryServiceStatusTranslation", Schema = "dbo")]
    public class MilitaryServiceStatusTranslation
    {
        public byte MilitaryServiceStatusId { get; set; }
        public short LanguageId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        [ForeignKey(nameof(MilitaryServiceStatusId))]
        public MilitaryServiceStatus MilitaryServiceStatus { get; set; } = null!;
    }
}
