using FluentValidation;
using VendaImoveis.Application.Extensions;
using VendaImoveis.Application.ViewModels.Corretor;
using VendaImoveis.Domain.Entities;
using VendaImoveis.Domain.Interfaces;
using VendaImoveis.Domain.Interfaces.Common;

namespace VendaImoveis.Application.Validations
{
    public class CorretorRequestValidator : 
        UsuarioImobiliariaRequestValidator<RequestCorretor, Corretor>
    {
        public CorretorRequestValidator(
            IBaseReadOnlyRepository<Corretor> repository,
            IUsuarioRepository usuarioRepository,
            IImobiliariaRepository imobiliariaRepository
            ) : base(repository, usuarioRepository)
        {
            RuleFor(x => x.CPF)
                .Length(14)
                .NotEmpty();

            RuleFor(x => x.CPF)
                .MustAsync((cpf, cancelToken) => repository.ExistAsync(x => x.CPF.Equals(cpf)))
                .WithMessage("{PropertyName} já existente");

            RuleFor(x => x.ImobiliariaId)
                .NotEqual(0)
                .ValidateForeignKey(imobiliariaRepository);

        }
    }
}
