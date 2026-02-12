using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KSS.Entity
{
    [Table("JobCategoryTranslation", Schema = "dbo")]
    public class JobCategoryTranslation
    {
        public short JobCategoryId { get; set; }
        public short LanguageId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [ForeignKey(nameof(JobCategoryId))]
        public JobCategory JobCategory { get; set; } = null!;
    }
}

