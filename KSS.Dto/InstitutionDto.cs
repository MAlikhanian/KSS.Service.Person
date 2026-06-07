namespace KSS.Dto
{
    public class InstitutionDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public int CountryId { get; set; }
        public int RegionId { get; set; }
        public int CityId { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
