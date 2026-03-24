namespace KSS.Dto
{
    public class BusinessUnitTranslationDto
    {
        public short BusinessUnitId { get; set; }
        public short LanguageId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
