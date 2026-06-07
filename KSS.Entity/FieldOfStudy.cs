using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KSS.Entity
{
    [Table("FieldOfStudy", Schema = "dbo")]
    public class FieldOfStudy
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [Unicode(false)]
        public string Code { get; set; } = string.Empty;
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsActive { get; set; } = true;

        public ICollection<FieldOfStudyTranslation> Translations { get; set; } = new List<FieldOfStudyTranslation>();
        public ICollection<Education> Educations { get; set; } = new List<Education>();
    }
}
