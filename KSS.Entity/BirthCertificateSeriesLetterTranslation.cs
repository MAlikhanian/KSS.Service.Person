using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KSS.Entity
{
    [Table("BirthCertificateSeriesLetterTranslation", Schema = "dbo")]
    public class BirthCertificateSeriesLetterTranslation
    {
        public byte BirthCertificateSeriesLetterId { get; set; }
        public short LanguageId { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; } = string.Empty;
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        [ForeignKey(nameof(BirthCertificateSeriesLetterId))]
        public BirthCertificateSeriesLetter BirthCertificateSeriesLetter { get; set; } = null!;
    }
}
