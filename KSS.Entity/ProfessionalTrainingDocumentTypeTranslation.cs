using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KSS.Entity
{
    [Table("ProfessionalTrainingDocumentTypeTranslation", Schema = "dbo")]
    public class ProfessionalTrainingDocumentTypeTranslation
    {
        public int ProfessionalTrainingDocumentTypeId { get; set; }
        public short LanguageId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        [ForeignKey(nameof(ProfessionalTrainingDocumentTypeId))]
        public ProfessionalTrainingDocumentType ProfessionalTrainingDocumentType { get; set; } = null!;
    }
}
