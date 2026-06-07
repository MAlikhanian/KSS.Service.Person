namespace KSS.Dto
{
    public class EmploymentDocumentAddDto
    {
        public Guid EmploymentId { get; set; }
        public int EmploymentDocumentTypeId { get; set; }
        public int StorageInstanceId { get; set; }
        public string FileName { get; set; } = string.Empty;
        public long FileSize { get; set; }
        public string ContentType { get; set; } = string.Empty;
    }
}
