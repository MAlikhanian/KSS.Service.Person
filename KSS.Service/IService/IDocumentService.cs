using KSS.Dto;
using KSS.Entity;

namespace KSS.Service.IService
{
    public interface IDocumentService : IBaseService<Document, DocumentListDto, DocumentAddDto, DocumentUpdateDto> { }
}
