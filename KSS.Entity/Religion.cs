using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KSS.Entity
{
    [Table("Religion", Schema = "dbo")]
    public class Religion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short Id { get; set; }
        [Required]
        [MaxLength(50)]
        [Unicode(false)]
        public string Code { get; set; } = string.Empty;

        public ICollection<ReligionTranslation> Translations { get; set; } = new List<ReligionTranslation>();
        public ICollection<Person> Persons { get; set; } = new List<Person>();
    }
}
