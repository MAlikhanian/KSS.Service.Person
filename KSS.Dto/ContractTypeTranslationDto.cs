namespace KSS.Dto
{
    public class ContractTypeTranslationDto
    {
        public byte ContractTypeId { get; set; }
        public short LanguageId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
