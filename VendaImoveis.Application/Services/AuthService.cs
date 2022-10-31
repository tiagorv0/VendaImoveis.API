using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using VendaImoveis.Application.Interfaces;

namespace VendaImoveis.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IHttpContextAccessor _accessor;

        public AuthService(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public int Id => int.Parse(GetClaims().FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value);
        public string Name => GetClaims().FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
        public string Email => GetClaims().FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
        public string Role => GetClaims().FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;

        public IEnumerable<Claim> GetClaims()
        {
            return _accessor.HttpContext.User.Claims;
        }

        public bool IsAuthenticated()
        {
            return _accessor.HttpContext.User.Identity.IsAuthenticated;
        }
    }
}
