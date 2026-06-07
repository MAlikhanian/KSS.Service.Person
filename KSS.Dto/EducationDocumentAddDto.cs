namespace KSS.Dto
{
    public class EducationDocumentAddDto
    {
        public Guid EducationId { get; set; }
        public int EducationDocumentTypeId { get; set; }
        public int StorageInstanceId { get; set; }
        public string FileName { get; set; } = string.Empty;
        public long FileSize { get; set; }
        public string ContentType { get; set; } = string.Empty;
    }
}
