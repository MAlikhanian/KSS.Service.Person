using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KSS.Entity
{
    [Table("EmploymentPosition", Schema = "dbo")]
    public class EmploymentPosition
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short Id { get; set; }
        public short EmploymentActivityUnitId { get; set; }
        [Required]
        [MaxLength(20)]
        [Unicode(false)]
        public string Code { get; set; } = string.Empty;
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsActive { get; set; } = true;

        public ICollection<EmploymentPositionTranslation> Translations { get; set; } = new List<EmploymentPositionTranslation>();
    }
}
