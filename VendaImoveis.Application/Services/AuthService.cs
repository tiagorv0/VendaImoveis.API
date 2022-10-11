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

        public int? Id => GetClaimIdentity<int>("Id");

        public string Name => GetClaimIdentity<string>("Name");

        public string RoleId => GetClaimIdentity<string>("RoleId");

        public string Email => GetClaimIdentity<string>("email");

        public string Token => GetCustomHeader("Authorization");

        public bool IsAuthenticated => _accessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;

        public IEnumerable<Claim> GetClaimsIdentity() => _accessor.HttpContext.User.Claims.ToList();

        private T GetClaimIdentity<T>(string type)
        {
            if (!IsAuthenticated) return default;

            var claim = _accessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == type);
            if (claim is null) return default;

            return (T)Convert.ChangeType(claim.Value, typeof(T));
        }

        private string GetCustomHeader(string header)
        {
            var headers = _accessor.HttpContext.Request.Headers;
            if (!headers.ContainsKey(header)) return null;

            return headers[header].ToString();
        }
    }
}
