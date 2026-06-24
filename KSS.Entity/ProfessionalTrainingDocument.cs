using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KSS.Entity
{
    [Table("ProfessionalTrainingDocument", Schema = "dbo")]
    public class ProfessionalTrainingDocument
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ProfessionalTrainingId { get; set; }
        public int ProfessionalTrainingDocumentTypeId { get; set; }
        public int StorageInstanceId { get; set; }
        [Required]
        [MaxLength(255)]
        public string FileName { get; set; } = string.Empty;
        public long FileSize { get; set; }
        [Required]
        [MaxLength(100)]
        [Unicode(false)]
        public string ContentType { get; set; } = string.Empty;
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsActive { get; set; } = true;

        [ForeignKey(nameof(ProfessionalTrainingId))]
        public ProfessionalTraining ProfessionalTraining { get; set; } = null!;
        [ForeignKey(nameof(ProfessionalTrainingDocumentTypeId))]
        public ProfessionalTrainingDocumentType ProfessionalTrainingDocumentType { get; set; } = null!;
    }
}
