using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KSS.Entity
{
    [Table("MilitaryServiceStatus", Schema = "dbo")]
    public class MilitaryServiceStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }
        [Required]
        [MaxLength(20)]
        [Unicode(false)]
        public string Code { get; set; } = string.Empty;

        public ICollection<MilitaryServiceStatusTranslation> Translations { get; set; } = new List<MilitaryServiceStatusTranslation>();
        public ICollection<Person> Persons { get; set; } = new List<Person>();
    }
}
