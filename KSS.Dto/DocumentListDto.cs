namespace KSS.Dto
{
    public class DocumentListDto
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public int DocumentTypeId { get; set; }
        public int StorageInstanceId { get; set; }
        public string FileName { get; set; } = string.Empty;
        public long FileSize { get; set; }
        public string ContentType { get; set; } = string.Empty;
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
