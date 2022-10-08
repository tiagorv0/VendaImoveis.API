using System.Security.Claims;

namespace VendaImoveis.Application.Interfaces
{
    public interface IAuthService
    {
        int? Id { get; }
        string Name { get; }
        string RoleId { get; }
        string Email { get; }
        string Token { get; }
        bool IsAuthenticated { get; }
        IEnumerable<Claim> GetClaimsIdentity();

    }
}
