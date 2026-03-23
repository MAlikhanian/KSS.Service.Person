using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KSS.Entity
{
    [Table("ContractTypeTranslation", Schema = "dbo")]
    public class ContractTypeTranslation
    {
        public byte ContractTypeId { get; set; }
        public short LanguageId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [ForeignKey(nameof(ContractTypeId))]
        public ContractType ContractType { get; set; } = null!;
    }
}
