using System.Security.Claims;

namespace VendaImoveis.Application.Token
{
    public interface ITokenGenerator
    {
        string GenerateToken(IEnumerable<Claim> claims);
    }
}
