using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KSS.Entity
{
    [Table("MilitaryServiceLocation", Schema = "dbo")]
    public class MilitaryServiceLocation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short Id { get; set; }
        [Required]
        [MaxLength(100)]
        [Unicode(false)]
        public string Code { get; set; } = string.Empty;

        public ICollection<MilitaryServiceLocationTranslation> Translations { get; set; } = new List<MilitaryServiceLocationTranslation>();
        public ICollection<Person> Persons { get; set; } = new List<Person>();
    }
}
