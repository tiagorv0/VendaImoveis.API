using System.Security.Claims;
using VendaImoveis.Domain.Interfaces.Common;

namespace VendaImoveis.Application.Interfaces
{
    public interface IAuthService : IService
    {
        int Id { get; }
        string Name { get; }
        string Email { get; }
        string Role { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaims();

    }
}
