using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KSS.Entity
{
    [Table("SexTranslation", Schema = "dbo")]
    public class SexTranslation
    {
        public byte SexId { get; set; }
        public short LanguageId { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; } = string.Empty;

        [ForeignKey(nameof(SexId))]
        public Sex Sex { get; set; } = null!;
    }
}

