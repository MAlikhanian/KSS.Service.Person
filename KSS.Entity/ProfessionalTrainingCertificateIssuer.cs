using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KSS.Entity
{
    [Table("ProfessionalTrainingCertificateIssuer", Schema = "dbo")]
    public class ProfessionalTrainingCertificateIssuer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        public ICollection<ProfessionalTrainingCertificateIssuerTranslation> Translations { get; set; } = new List<ProfessionalTrainingCertificateIssuerTranslation>();
        public ICollection<ProfessionalTraining> ProfessionalTrainings { get; set; } = new List<ProfessionalTraining>();
    }
}
