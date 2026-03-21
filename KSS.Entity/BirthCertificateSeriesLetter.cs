using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KSS.Entity
{
    [Table("BirthCertificateSeriesLetter", Schema = "dbo")]
    public class BirthCertificateSeriesLetter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }
        [Required]
        [MaxLength(10)]
        [Unicode(false)]
        public string Code { get; set; } = string.Empty;

        public ICollection<BirthCertificateSeriesLetterTranslation> Translations { get; set; } = new List<BirthCertificateSeriesLetterTranslation>();
        public ICollection<Person> Persons { get; set; } = new List<Person>();
    }
}
