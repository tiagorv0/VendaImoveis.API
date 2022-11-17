using Microsoft.AspNetCore.Http;
using VendaImoveis.Application.ViewModels.Propriedade;
using VendaImoveis.Domain.Interfaces.Common;

namespace VendaImoveis.Application.Interfaces.Storage
{
    public interface IPropriedadeFileStorageService : IFileStorageService<ResponsePropriedade>, IService
    {
        Task<ResponsePropriedade> UploadManyImgAsync(int id, IList<IFormFile> images);
        FileStream GetAllImg(int id);
        Task<ResponsePropriedade> RemoveOnlyOneImgAsync(int id, int index);
    }
}
