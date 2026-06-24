using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KSS.Entity
{
    [Table("EmploymentActivityFieldTranslation", Schema = "dbo")]
    public class EmploymentActivityFieldTranslation
    {
        public short EmploymentActivityFieldId { get; set; }
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

        [ForeignKey(nameof(EmploymentActivityFieldId))]
        public EmploymentActivityField EmploymentActivityField { get; set; } = null!;
    }
}
