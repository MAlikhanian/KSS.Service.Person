using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KSS.Entity
{
    [Table("JobDepartmentTranslation", Schema = "dbo")]
    public class JobDepartmentTranslation
    {
        public short JobDepartmentId { get; set; }
        public short LanguageId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [ForeignKey(nameof(JobDepartmentId))]
        public JobDepartment JobDepartment { get; set; } = null!;
    }
}

