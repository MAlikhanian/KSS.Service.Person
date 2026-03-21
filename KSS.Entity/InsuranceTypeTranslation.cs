using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KSS.Entity
{
    [Table("InsuranceTypeTranslation", Schema = "dbo")]
    public class InsuranceTypeTranslation
    {
        public byte InsuranceTypeId { get; set; }
        public short LanguageId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [ForeignKey(nameof(InsuranceTypeId))]
        public InsuranceType InsuranceType { get; set; } = null!;
    }
}
