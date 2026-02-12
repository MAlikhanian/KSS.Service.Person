namespace KSS.Dto
{
    public class RelationshipDto
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public Guid RelatedPersonId { get; set; }
        public byte RelationshipTypeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
