using VendaImoveis.Application.Common.Interfaces;
using VendaImoveis.Application.Interfaces;
using VendaImoveis.Application.Services;
using VendaImoveis.Application.Services.Common;
using VendaImoveis.Application.Token;
using VendaImoveis.Domain.Interfaces.Common;
using VendaImoveis.Infrastructure.Repositories.Common;
using VendaImoveis.Infrastructure.UnitOfWork;
using FluentValidation.AspNetCore;
using VendaImoveis.Application.Validations;
using VendaImoveis.Application.Mappers;

namespace VendaImoveis.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddHttpContextAccessor();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IBaseReadOnlyRepository<>), typeof(BaseReadOnlyRepository<>));
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddScoped(typeof(ICrudService<,,,,>), typeof(CrudService<,,,,>));
            services.AddScoped(typeof(IReadOnlyService<,,,,>), typeof(ReadOnlyService<,,,,>));

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenGenerator, TokenGenerator>();

            services.AddFluentValidation(x =>
            {
                x.AutomaticValidationEnabled = false;
                x.RegisterValidatorsFromAssemblyContaining<UsuarioRequestValidator>();
            });

            services.AddAutoMapper(typeof(VendaImoveisProfile));

            return services;
        }
    }
}
