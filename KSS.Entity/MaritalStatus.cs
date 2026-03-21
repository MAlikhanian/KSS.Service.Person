using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KSS.Entity
{
    [Table("MaritalStatus", Schema = "dbo")]
    public class MaritalStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }
        [Required]
        [MaxLength(10)]
        [Unicode(false)]
        public string Code { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

        public ICollection<MaritalStatusTranslation> Translations { get; set; } = new List<MaritalStatusTranslation>();
        public ICollection<Person> Persons { get; set; } = new List<Person>();
    }
}
