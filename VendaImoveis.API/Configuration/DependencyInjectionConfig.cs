using FluentValidation;
using VendaImoveis.Application.Extensions;
using VendaImoveis.Application.Interfaces.Common;
using VendaImoveis.Application.Mappers;
using VendaImoveis.Application.Options;
using VendaImoveis.Application.Services.Common;
using VendaImoveis.Application.Token;
using VendaImoveis.Application.Validations;
using VendaImoveis.Domain.Interfaces.Common;
using VendaImoveis.Domain.Interfaces.Storage;
using VendaImoveis.Infrastructure.Repositories.Common;
using VendaImoveis.Infrastructure.Storage;
using VendaImoveis.Infrastructure.UnitOfWork;

namespace VendaImoveis.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            //storage
            services.AddSingleton<IFileStorage, FileStorage>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpContextAccessor();

            //options
            services.Configure<FileSettings>(configuration.GetSection("FileSettings"));

            //repositores and services
            services.AddRepositoriesAutomatically();
            services.AddServicesAutomatically();
            services.AddScoped(typeof(IBaseReadOnlyRepository<>), typeof(BaseReadOnlyRepository<>));
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(ICrudService<,,,,>), typeof(CrudService<,,,,>));
            services.AddScoped(typeof(IReadOnlyService<,,,,>), typeof(ReadOnlyService<,,,,>));

            //uow
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //tokenGenerator
            services.AddScoped<ITokenGenerator, TokenGenerator>();

            //mapper and fluentValidation
            services.AddAutoMapper(typeof(VendaImoveisProfile));
            services.AddValidatorsFromAssemblyContaining<PropriedadeRequestValidator>();

            return services;
        }

        private static void AddServicesAutomatically(this IServiceCollection services)
        {
            var servicesTypes = AppDomain.CurrentDomain
                .GetAssemblies()
                .Where(t => t.FullName.StartsWith("VendaImoveis"))
                .SelectMany(a => a.GetTypes())
                .Where(t => t.IsClass && !t.IsAbstract)
                .Where(t => typeof(IService).IsAssignableFrom(t))
                .Where(t => !t.ContainsGenericParameters)
                .ToList();

            servicesTypes.ForEach(serviceType => serviceType
                .GetDirectInterfaces()
                .ToList()
                .ForEach(@interface => services.AddScoped(@interface, serviceType)));
        }

        private static void AddRepositoriesAutomatically(this IServiceCollection services)
        {
            var repositoryTypes = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => t.IsClass && !t.IsAbstract)
                .Where(t => t.IsAssignableToGenericType(typeof(IBaseReadOnlyRepository<>)))
                .Where(t => !t.ContainsGenericParameters)
                .ToList();

            repositoryTypes.ForEach(repositoryType => repositoryType
                .GetDirectInterfaces().ToList()
                .ForEach(@interface => services.AddScoped(@interface, repositoryType))
            );
        }
    }
}
