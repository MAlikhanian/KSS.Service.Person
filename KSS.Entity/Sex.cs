using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KSS.Entity
{
    [Table("Sex", Schema = "dbo")]
    public class Sex
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }
        [Required]
        [MaxLength(10)]
        [Unicode(false)]
        public string Code { get; set; } = string.Empty;

        public ICollection<SexTranslation> Translations { get; set; } = new List<SexTranslation>();
        public ICollection<Person> Persons { get; set; } = new List<Person>();
    }
}

