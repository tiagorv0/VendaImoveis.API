using FluentValidation;
using VendaImoveis.Application.Extensions;
using VendaImoveis.Application.Interfaces;
using VendaImoveis.Application.Utils;
using VendaImoveis.Application.ViewModels.Corretor;
using VendaImoveis.Domain.Entities;
using VendaImoveis.Domain.Interfaces;

namespace VendaImoveis.Application.Validations
{
    public class CorretorRequestValidator :
        UsuarioImobiliariaRequestValidator<RequestCorretor, Corretor>
    {
        public CorretorRequestValidator(
            ICorretorRepository corretorRepository,
            IImobiliariaRepository imobiliariaRepository,
            IAuthService authService
        ) : base(corretorRepository, authService)
        {
            RuleFor(x => x.CPF)
                .Length(14)
                .NotEmpty();

            RuleFor(x => x.CPF)
                .ValidateCPF(corretorRepository, authService);

            RuleFor(x => x.CPF)
                .Must(cpf => PropertyValidation.CPFEhValido(cpf))
                .WithMessage("{PropertyName} não é válido!");

            RuleFor(x => x.ImobiliariaId)
                .NotEqual(0)
                .ValidateForeignKey(imobiliariaRepository);

        }
    }
}
