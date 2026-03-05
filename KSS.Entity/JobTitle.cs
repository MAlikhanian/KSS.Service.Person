using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KSS.Entity
{
    [Table("JobTitle", Schema = "dbo")]
    public class JobTitle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short Id { get; set; }
        public short JobDepartmentId { get; set; }
        [Required]
        [MaxLength(10)]
        [Unicode(false)]
        public string Code { get; set; } = string.Empty;

        [ForeignKey(nameof(JobDepartmentId))]
        public JobDepartment JobDepartment { get; set; } = null!;
        public ICollection<JobTitleTranslation> Translations { get; set; } = new List<JobTitleTranslation>();
        public ICollection<Employment> Employments { get; set; } = new List<Employment>();
    }
}

