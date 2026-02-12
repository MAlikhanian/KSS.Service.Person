namespace KSS.Dto
{
    public class RelationshipTypeTranslationDto
    {
        public byte RelationshipTypeId { get; set; }
        public short LanguageId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
