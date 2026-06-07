namespace KSS.Dto
{
    public class DocumentAddDto
    {
        public Guid PersonId { get; set; }
        public int DocumentTypeId { get; set; }
        public int StorageInstanceId { get; set; }
        public string FileName { get; set; } = string.Empty;
        public long FileSize { get; set; }
        public string ContentType { get; set; } = string.Empty;
    }
}
