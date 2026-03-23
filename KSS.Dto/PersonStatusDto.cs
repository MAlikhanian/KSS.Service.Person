namespace KSS.Dto
{
    public class PersonStatusDto
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
