using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KSS.Entity
{
    [Table("ContractType", Schema = "dbo")]
    public class ContractType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }
        [Required]
        [MaxLength(20)]
        [Unicode(false)]
        public string Code { get; set; } = string.Empty;

        public ICollection<ContractTypeTranslation> Translations { get; set; } = new List<ContractTypeTranslation>();
        public ICollection<Employment> Employments { get; set; } = new List<Employment>();
    }
}
