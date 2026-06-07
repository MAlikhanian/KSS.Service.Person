namespace KSS.Dto
{
    public class AddressTranslationDto
    {
        public Guid AddressId { get; set; }
        public short LanguageId { get; set; }
        public string Street1 { get; set; } = string.Empty;
        public string? Street2 { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
