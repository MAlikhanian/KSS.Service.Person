using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KSS.Entity
{
    [Table("InsuranceType", Schema = "dbo")]
    public class InsuranceType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }
        [Required]
        [MaxLength(20)]
        [Unicode(false)]
        public string Code { get; set; } = string.Empty;

        public ICollection<InsuranceTypeTranslation> Translations { get; set; } = new List<InsuranceTypeTranslation>();
        public ICollection<Person> Persons { get; set; } = new List<Person>();
    }
}
