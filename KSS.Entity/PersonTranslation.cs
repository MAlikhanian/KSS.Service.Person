using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KSS.Entity
{
    [Table("PersonTranslation", Schema = "dbo")]
    public class PersonTranslation
    {
        public Guid PersonId { get; set; }
        public short LanguageId { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;
        [MaxLength(50)]
        public string? FatherName { get; set; }
        [MaxLength(100)]
        public string? DisplayName { get; set; }

        [ForeignKey(nameof(PersonId))]
        public Person Person { get; set; } = null!;
    }
}

