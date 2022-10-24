using System.Security.Claims;
using VendaImoveis.Domain.Interfaces.Common;

namespace VendaImoveis.Application.Interfaces
{
    public interface IAuthService : IService
    {
        int? Id { get; }
        string Name { get; }
        string Role { get; }
        string Email { get; }
        string Token { get; }
        bool IsAuthenticated { get; }
        IEnumerable<Claim> GetClaimsIdentity();

    }
}
