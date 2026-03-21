using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KSS.Entity
{
    [Table("MaritalStatusTranslation", Schema = "dbo")]
    public class MaritalStatusTranslation
    {
        public byte MaritalStatusId { get; set; }
        public short LanguageId { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; } = string.Empty;

        [ForeignKey(nameof(MaritalStatusId))]
        public MaritalStatus MaritalStatus { get; set; } = null!;
    }
}
