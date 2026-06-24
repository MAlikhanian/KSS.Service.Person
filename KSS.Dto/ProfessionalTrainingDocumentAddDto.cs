namespace KSS.Dto
{
    public class ProfessionalTrainingDocumentAddDto
    {
        public Guid ProfessionalTrainingId { get; set; }
        public int ProfessionalTrainingDocumentTypeId { get; set; }
        public int StorageInstanceId { get; set; }
        public string FileName { get; set; } = string.Empty;
        public long FileSize { get; set; }
        public string ContentType { get; set; } = string.Empty;
    }
}
