using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KSS.Entity
{
    [Table("PersonNationality", Schema = "dbo")]
    public class PersonNationality
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public short CountryId { get; set; }

        [ForeignKey(nameof(PersonId))]
        public Person Person { get; set; } = null!;
    }
}
