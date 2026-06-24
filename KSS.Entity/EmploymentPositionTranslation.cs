using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KSS.Entity
{
    [Table("EmploymentPositionTranslation", Schema = "dbo")]
    public class EmploymentPositionTranslation
    {
        public short EmploymentPositionId { get; set; }
        public short LanguageId { get; set; }
        [Required]
        [MaxLength(80)]
        public string Name { get; set; } = string.Empty;
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        [ForeignKey(nameof(EmploymentPositionId))]
        public EmploymentPosition EmploymentPosition { get; set; } = null!;
    }
}
