using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KSS.Entity
{
    [Table("JobDepartment", Schema = "dbo")]
    public class JobDepartment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short Id { get; set; }
        public short JobCategoryId { get; set; }
        [Required]
        [MaxLength(10)]
        [Unicode(false)]
        public string Code { get; set; } = string.Empty;

        [ForeignKey(nameof(JobCategoryId))]
        public JobCategory JobCategory { get; set; } = null!;
        public ICollection<JobDepartmentTranslation> Translations { get; set; } = new List<JobDepartmentTranslation>();
        public ICollection<JobTitle> JobTitles { get; set; } = new List<JobTitle>();
    }
}

