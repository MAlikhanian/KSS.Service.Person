using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KSS.Entity
{
    [Table("EmploymentDocument", Schema = "dbo")]
    public class EmploymentDocument
    {
        [Key]
        public Guid Id { get; set; }
        public Guid EmploymentId { get; set; }
        public int EmploymentDocumentTypeId { get; set; }
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

        [ForeignKey(nameof(EmploymentId))]
        public Employment Employment { get; set; } = null!;
        [ForeignKey(nameof(EmploymentDocumentTypeId))]
        public EmploymentDocumentType EmploymentDocumentType { get; set; } = null!;
    }
}
