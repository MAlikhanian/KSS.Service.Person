using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KSS.Entity
{
    [Table("JobTitleTranslation", Schema = "dbo")]
    public class JobTitleTranslation
    {
        public short JobTitleId { get; set; }
        public short LanguageId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [ForeignKey(nameof(JobTitleId))]
        public JobTitle JobTitle { get; set; } = null!;
    }
}

