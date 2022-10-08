using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using VendaImoveis.Application.Interfaces;

namespace VendaImoveis.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IHttpContextAccessor _acessor;

        public AuthService(IHttpContextAccessor acessor)
        {
            _acessor = acessor;
        }

        public int? Id => throw new NotImplementedException();

        public string Name => throw new NotImplementedException();

        public string RoleId => throw new NotImplementedException();

        public string Email => throw new NotImplementedException();

        public string Token => throw new NotImplementedException();

        public bool IsAuthenticated => _acessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;

        public IEnumerable<Claim> GetClaimsIdentity() => _acessor.HttpContext.User.Claims.ToList();
    }
}
