using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KSS.Entity
{
    [Table("BusinessSectorTranslation", Schema = "dbo")]
    public class BusinessSectorTranslation
    {
        public short BusinessSectorId { get; set; }
        public short LanguageId { get; set; }
        [Required]
        [MaxLength(80)]
        public string Name { get; set; } = string.Empty;

        [ForeignKey(nameof(BusinessSectorId))]
        public BusinessSector BusinessSector { get; set; } = null!;
    }
}
