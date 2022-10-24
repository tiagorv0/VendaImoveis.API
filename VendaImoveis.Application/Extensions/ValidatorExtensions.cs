using FluentValidation;
using VendaImoveis.Application.Interfaces;
using VendaImoveis.Domain.Core;
using VendaImoveis.Domain.Interfaces;
using VendaImoveis.Domain.Interfaces.Common;
using VendaImoveis.Infrastructure.Repositories;

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
            return ruleBuilder.Must(cpf => repository.ExistAsync(x => x.UsuarioId == authService.Id && x.CPF.Equals(cpf)).Result);
        }

        public static IRuleBuilderOptions<T, string> ValidateCNPJ<T>(
            this IRuleBuilder<T, string> ruleBuilder, IImobiliariaRepository repository,
            IAuthService authService)
        {
            return ruleBuilder.Must(cnpj => repository.ExistAsync(x => x.UsuarioId == authService.Id && x.CNPJ.Equals(cnpj)).Result);
        }
    }
}
