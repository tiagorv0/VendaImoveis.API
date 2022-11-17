using Microsoft.AspNetCore.Http;
using VendaImoveis.Domain.Core;

namespace VendaImoveis.Application.Interfaces.Storage
{
    public interface IFileStorageService<TResponse>
        where TResponse : Registro
    {
        Task<TResponse> RemoveImgAsync(int id);
        FileStream GetImg(int id);
    }
}
