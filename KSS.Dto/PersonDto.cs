namespace KSS.Dto
{
    public class PersonDto
    {
        public Guid Id { get; set; }
        public byte SexId { get; set; }
        public short PreferredLanguageId { get; set; }
        public string NationalId { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public short BirthCountryId { get; set; }
        public short BirthRegionId { get; set; }
        public int BirthCityId { get; set; }
        public short NationalityCountryId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        // Related entities
        public ICollection<PersonTranslationDto> Translations { get; set; } = new List<PersonTranslationDto>();
        public ICollection<EmailDto> Emails { get; set; } = new List<EmailDto>();
        public ICollection<PhoneDto> Phones { get; set; } = new List<PhoneDto>();
        public ICollection<AddressDto> Addresses { get; set; } = new List<AddressDto>();
        public ICollection<EmploymentDto> Employments { get; set; } = new List<EmploymentDto>();
    }
}

