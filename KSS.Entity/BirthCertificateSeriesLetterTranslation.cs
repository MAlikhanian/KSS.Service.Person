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

        [ForeignKey(nameof(BirthCertificateSeriesLetterId))]
        public BirthCertificateSeriesLetter BirthCertificateSeriesLetter { get; set; } = null!;
    }
}
