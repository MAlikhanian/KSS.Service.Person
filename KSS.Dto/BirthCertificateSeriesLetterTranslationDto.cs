namespace KSS.Dto
{
    public class BirthCertificateSeriesLetterTranslationDto
    {
        public byte BirthCertificateSeriesLetterId { get; set; }
        public short LanguageId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
