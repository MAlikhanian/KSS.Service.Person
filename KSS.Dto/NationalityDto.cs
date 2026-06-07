namespace KSS.Dto
{
    public class NationalityDto
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public short CountryId { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
