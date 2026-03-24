using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KSS.Entity
{
    [Table("JobPositionTranslation", Schema = "dbo")]
    public class JobPositionTranslation
    {
        public short JobPositionId { get; set; }
        public short LanguageId { get; set; }
        [Required]
        [MaxLength(80)]
        public string Name { get; set; } = string.Empty;

        [ForeignKey(nameof(JobPositionId))]
        public JobPosition JobPosition { get; set; } = null!;
    }
}
