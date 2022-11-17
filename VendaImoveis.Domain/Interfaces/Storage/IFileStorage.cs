using Microsoft.AspNetCore.Http;

namespace VendaImoveis.Domain.Interfaces.Storage
{
    public interface IFileStorage
    {
        Task<bool> UploadFileAsync(IFormFile file, string filePath);
        Task<bool> RemoveFile(string filePath);
        Task<bool> IfNotExistCreateDirectory(string directory);
        FileStream GetFile(string filePath);

    }
}
