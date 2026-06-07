namespace KSS.Dto
{
    public class DocumentUpdateDto
    {
        public Guid Id { get; set; }
        public int DocumentTypeId { get; set; }
        public string FileName { get; set; } = string.Empty;
    }
}
