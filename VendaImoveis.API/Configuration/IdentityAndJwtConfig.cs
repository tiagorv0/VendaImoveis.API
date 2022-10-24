using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using VendaImoveis.Application.Constants;

namespace VendaImoveis.API.Configuration
{
    public static class IdentityAndJwtConfig
    {
        public static IServiceCollection AddIdentityAndJwtConfiguration(
            this IServiceCollection services, IConfiguration configuration)
        {
            var secretKey = configuration["Jwt:Key"];

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true
                };
            });

            services.AddAuthorization(opt =>
            {
                opt.AddPolicy(Roles.Imobiliaria, policy => policy.RequireRole(Roles.Imobiliaria));
                opt.AddPolicy(Roles.Corretor, policy => policy.RequireRole(Roles.Corretor));
                opt.AddPolicy(Roles.Comum, policy => policy.RequireRole(Roles.Comum));
            });

            return services;
        }
    }
}
