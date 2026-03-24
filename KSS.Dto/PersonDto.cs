using System.ComponentModel.DataAnnotations;

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
        public string? BirthCertificateNumber { get; set; }
        [MaxLength(2)]
        public string? BirthCertificateSeriesNumber { get; set; }
        public byte? BirthCertificateSeriesLetterId { get; set; }
        [MaxLength(6)]
        public string? BirthCertificateSerial { get; set; }
        public short BirthCertificateIssueCountryId { get; set; }
        public short BirthCertificateIssueRegionId { get; set; }
        public int BirthCertificateIssueCityId { get; set; }
        public byte MaritalStatusId { get; set; }
        public short? ReligionId { get; set; }
        public string? PassportNumber { get; set; }
        public byte? MilitaryServiceStatusId { get; set; }
        public short? MilitaryServiceLocationId { get; set; }
        public byte? InsuranceTypeId { get; set; }
        public string? InsuranceNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        // Related entities
        public ICollection<PersonTranslationDto> Translations { get; set; } = new List<PersonTranslationDto>();
        public ICollection<EmailDto> Emails { get; set; } = new List<EmailDto>();
        public ICollection<PhoneDto> Phones { get; set; } = new List<PhoneDto>();
        public ICollection<AddressDto> Addresses { get; set; } = new List<AddressDto>();
        public ICollection<EmploymentDto> Employments { get; set; } = new List<EmploymentDto>();
        public ICollection<PersonNationalityDto> Nationalities { get; set; } = new List<PersonNationalityDto>();
        public ICollection<RelationshipDto> RelationshipsAsPerson { get; set; } = new List<RelationshipDto>();
        public ICollection<PersonStatusDto> Statuses { get; set; } = new List<PersonStatusDto>();
    }
}

