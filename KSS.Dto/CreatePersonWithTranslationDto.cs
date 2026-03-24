using System.ComponentModel.DataAnnotations;

namespace KSS.Dto
{
    public class CreatePersonWithTranslationDto
    {
        public byte SexId { get; set; } = 1;

        public short PreferredLanguageId { get; set; } = 12;

        [MaxLength(20)]
        public string? NationalId { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public short BirthCountryId { get; set; } = 1;

        public short BirthRegionId { get; set; } = 1;

        public int BirthCityId { get; set; } = 1;

        [MaxLength(20)]
        public string? BirthCertificateNumber { get; set; }

        [MaxLength(2)]
        public string? BirthCertificateSeriesNumber { get; set; }

        public byte? BirthCertificateSeriesLetterId { get; set; }

        [MaxLength(6)]
        public string? BirthCertificateSerial { get; set; }

        public short BirthCertificateIssueCountryId { get; set; } = 1;

        public short BirthCertificateIssueRegionId { get; set; } = 1;

        public int BirthCertificateIssueCityId { get; set; } = 1;

        public byte MaritalStatusId { get; set; } = 1;

        public short? ReligionId { get; set; }

        [MaxLength(20)]
        public string? PassportNumber { get; set; }

        public byte? MilitaryServiceStatusId { get; set; }

        public short? MilitaryServiceLocationId { get; set; }

        public byte? InsuranceTypeId { get; set; }

        [MaxLength(30)]
        public string? InsuranceNumber { get; set; }

        /// <summary>
        /// Translations for FA and EN (like company pattern).
        /// Each entry must have LanguageId, FirstName, LastName. FatherName is optional.
        /// </summary>
        public List<PersonTranslationDto> Translations { get; set; } = new();
    }
}
