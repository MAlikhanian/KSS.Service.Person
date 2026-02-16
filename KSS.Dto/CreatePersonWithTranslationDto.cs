using System.ComponentModel.DataAnnotations;

namespace KSS.Dto
{
    public class CreatePersonWithTranslationDto
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        public byte SexId { get; set; } = 1;

        public short PreferredLanguageId { get; set; } = 1;

        [MaxLength(20)]
        public string? NationalId { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public short BirthCountryId { get; set; } = 1;

        public short BirthRegionId { get; set; } = 1;

        public int BirthCityId { get; set; } = 1;

        public short NationalityCountryId { get; set; } = 1;
    }
}
