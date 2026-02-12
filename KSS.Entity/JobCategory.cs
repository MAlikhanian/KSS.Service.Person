using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KSS.Entity
{
    [Table("JobCategory", Schema = "dbo")]
    public class JobCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short Id { get; set; }
        [Required]
        [MaxLength(10)]
        public string Code { get; set; } = string.Empty;

        public ICollection<JobCategoryTranslation> Translations { get; set; } = new List<JobCategoryTranslation>();
        public ICollection<JobDepartment> JobDepartments { get; set; } = new List<JobDepartment>();
    }
}

