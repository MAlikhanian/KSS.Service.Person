using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KSS.Entity
{
    [Table("ProfessionalTraining", Schema = "dbo")]
    public class ProfessionalTraining
    {
        [Key]
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;
        public int ProfessionalTrainingTypeId { get; set; }
        public int ProfessionalTrainingCertificateIssuerId { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsActive { get; set; } = true;

        [ForeignKey(nameof(PersonId))]
        public Person Person { get; set; } = null!;
        [ForeignKey(nameof(ProfessionalTrainingTypeId))]
        public ProfessionalTrainingType ProfessionalTrainingType { get; set; } = null!;
        [ForeignKey(nameof(ProfessionalTrainingCertificateIssuerId))]
        public ProfessionalTrainingCertificateIssuer ProfessionalTrainingCertificateIssuer { get; set; } = null!;
        public ICollection<ProfessionalTrainingDocument> ProfessionalTrainingDocuments { get; set; } = new List<ProfessionalTrainingDocument>();
    }
}
