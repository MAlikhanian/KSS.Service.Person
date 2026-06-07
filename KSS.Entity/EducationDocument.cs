using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KSS.Entity
{
    [Table("EducationDocument", Schema = "dbo")]
    public class EducationDocument
    {
        [Key]
        public Guid Id { get; set; }
        public Guid EducationId { get; set; }
        public int EducationDocumentTypeId { get; set; }
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

        [ForeignKey(nameof(EducationId))]
        public Education Education { get; set; } = null!;
        [ForeignKey(nameof(EducationDocumentTypeId))]
        public EducationDocumentType EducationDocumentType { get; set; } = null!;
    }
}
