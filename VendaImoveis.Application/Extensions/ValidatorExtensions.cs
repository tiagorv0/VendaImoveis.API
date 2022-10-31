using FluentValidation;
using VendaImoveis.Application.Interfaces;
using VendaImoveis.Domain.Core;
using VendaImoveis.Domain.Interfaces;
using VendaImoveis.Domain.Interfaces.Common;

namespace VendaImoveis.Application.Extensions
{
    public static class ValidatorExtensions
    {
        public static IRuleBuilderOptions<T, int> ValidateForeignKey<T, TEntity>(
            this IRuleBuilder<T, int> ruleBuilder, IBaseReadOnlyRepository<TEntity> repository)
            where TEntity : Registro
        {
            return ruleBuilder.Must(id => repository.ExistAsync(id).Result)
                .WithMessage("{PropertyName} com o valor: {PropertyValue} não existe.");
        }

        public static IRuleBuilderOptions<T, string> ValidateCPF<T>(
            this IRuleBuilder<T, string> ruleBuilder, ICorretorRepository repository,
            IAuthService authService)
        {
            return ruleBuilder.Must(cpf =>
            {
                var corretores = repository.GetAllAsync(x => x.CPF == cpf).Result;
                return corretores.All(x => x.Id == authService.Id);
            })
                .WithMessage("{PropertyName} já existente");
        }

        public static IRuleBuilderOptions<T, string> ValidateCNPJ<T>(
            this IRuleBuilder<T, string> ruleBuilder, IImobiliariaRepository repository,
            IAuthService authService)
        {
            return ruleBuilder.Must(cnpj =>
            {
                var imobiliarias = repository.GetAllAsync(x => x.CNPJ == cnpj).Result;
                return imobiliarias.All(x => x.Id == authService.Id);
            })
                .WithMessage("{PropertyName} já existente");
        }

        public static IRuleBuilderOptions<T, string> ValidateCRECI<T, TEntity>(
            this IRuleBuilder<T, string> ruleBuilder, IBaseReadOnlyRepository<TEntity> repository,
            IAuthService authService)
            where TEntity : UsuariosImobiliaria
        {
            return ruleBuilder.Must(creci =>
            {
                var imobiliarias = repository.GetAllAsync(x => x.CRECI == creci).Result;
                return imobiliarias.All(x => x.Id == authService.Id);
            })
                .WithMessage("{PropertyName} já existente");
        }

        public static IRuleBuilderOptions<T, string> ValidateNomeUsuario<T, TEntity>(
            this IRuleBuilder<T, string> ruleBuilder, IBaseReadOnlyRepository<TEntity> repository,
            IAuthService authService)
            where TEntity : Usuario
        {
            return ruleBuilder.Must(nomeUsuario =>
            {
                var usuarios = repository.GetAllAsync(x => x.NomeUsuario == nomeUsuario).Result;
                return usuarios.All(x => x.Id == authService.Id);
            })
                .WithMessage("{PropertyName} já existente");
        }

        public static IRuleBuilderOptions<T, string> ValidateEmail<T, TEntity>(
            this IRuleBuilder<T, string> ruleBuilder, IBaseReadOnlyRepository<TEntity> repository,
            IAuthService authService)
            where TEntity : Usuario
        {
            return ruleBuilder.Must(email =>
            {
                var usuarios = repository.GetAllAsync(x => x.Email == email).Result;
                return usuarios.All(x => x.Id == authService.Id);
            })
                .WithMessage("{PropertyName} já existente");
        }
    }
}
