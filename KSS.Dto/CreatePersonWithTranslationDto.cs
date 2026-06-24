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

        public short? BirthCountryId { get; set; }

        public short? BirthRegionId { get; set; }

        public int? BirthCityId { get; set; }

        [MaxLength(20)]
        public string? BirthCertificateNumber { get; set; }

        [MaxLength(2)]
        public string? BirthCertificateSeriesNumber { get; set; }

        public byte? BirthCertificateSeriesLetterId { get; set; }

        [MaxLength(6)]
        public string? BirthCertificateSerial { get; set; }

        public short? BirthCertificateIssueCountryId { get; set; }

        public short? BirthCertificateIssueRegionId { get; set; }

        public int? BirthCertificateIssueCityId { get; set; }

        public byte? MaritalStatusId { get; set; }

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
        public List<TranslationDto> Translations { get; set; } = new();
    }
}
