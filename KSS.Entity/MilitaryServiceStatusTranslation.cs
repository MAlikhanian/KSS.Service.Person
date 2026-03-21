using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KSS.Entity
{
    [Table("MilitaryServiceStatusTranslation", Schema = "dbo")]
    public class MilitaryServiceStatusTranslation
    {
        public byte MilitaryServiceStatusId { get; set; }
        public short LanguageId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [ForeignKey(nameof(MilitaryServiceStatusId))]
        public MilitaryServiceStatus MilitaryServiceStatus { get; set; } = null!;
    }
}
