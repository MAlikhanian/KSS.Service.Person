using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KSS.Entity
{
    [Table("FieldOfStudyTranslation", Schema = "dbo")]
    public class FieldOfStudyTranslation
    {
        public int FieldOfStudyId { get; set; }
        public short LanguageId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        [ForeignKey(nameof(FieldOfStudyId))]
        public FieldOfStudy FieldOfStudy { get; set; } = null!;
    }
}
