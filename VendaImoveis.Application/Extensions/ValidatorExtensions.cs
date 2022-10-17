using FluentValidation;
using VendaImoveis.Domain.Core;
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
    }
}
