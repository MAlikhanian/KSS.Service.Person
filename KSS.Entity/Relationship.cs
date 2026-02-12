using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KSS.Entity
{
    [Table("Relationship", Schema = "dbo")]
    public class Relationship
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public Guid RelatedPersonId { get; set; }
        public byte RelationshipTypeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [ForeignKey(nameof(PersonId))]
        public Person Person { get; set; } = null!;
        [ForeignKey(nameof(RelatedPersonId))]
        public Person RelatedPerson { get; set; } = null!;
        [ForeignKey(nameof(RelationshipTypeId))]
        public RelationshipType RelationshipType { get; set; } = null!;
    }
}

