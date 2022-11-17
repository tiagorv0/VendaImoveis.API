using Microsoft.AspNetCore.Http;
using VendaImoveis.Application.ViewModels.Imobiliaria;
using VendaImoveis.Domain.Interfaces.Common;

namespace VendaImoveis.Application.Interfaces.Storage
{
    public interface IImobiliariaFileStorageService : IFileStorageService<ResponseImobiliaria>, IService
    {
        Task<ResponseImobiliaria> UploadLogoAsync(int id, IFormFile image);
    }
}
