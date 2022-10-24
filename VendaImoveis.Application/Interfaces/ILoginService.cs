using System.Security.Claims;
using VendaImoveis.Application.ViewModels.Login;
using VendaImoveis.Domain.Interfaces.Common;

namespace VendaImoveis.Application.Interfaces
{
    public interface ILoginService : IService
    {
        Task<IEnumerable<Claim>> Login(LoginViewModel model);
    }
}
