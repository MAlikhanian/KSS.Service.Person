using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KSS.Entity
{
    [Table("MilitaryServiceLocationTranslation", Schema = "dbo")]
    public class MilitaryServiceLocationTranslation
    {
        public short MilitaryServiceLocationId { get; set; }
        public short LanguageId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [ForeignKey(nameof(MilitaryServiceLocationId))]
        public MilitaryServiceLocation MilitaryServiceLocation { get; set; } = null!;
    }
}
