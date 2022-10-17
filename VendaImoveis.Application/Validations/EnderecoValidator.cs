using FluentValidation;
using VendaImoveis.Application.ViewModels.Endereco;

namespace VendaImoveis.Application.Validations
{
    public class EnderecoValidator : AbstractValidator<EnderecoViewModel>
    {
        public EnderecoValidator()
        {
            RuleFor(x => x.Rua)
                .MinimumLength(3)
                .MaximumLength(80)
                .NotEmpty();

            RuleFor(x => x.CEP)
                .Length(9)
                .NotEmpty();

            RuleFor(x => x.Bairro)
                .NotEmpty();

            RuleFor(x => x.Cidade)
                .NotEmpty();

            RuleFor(x => x.Estado)
                .Length(2)
                .NotEmpty();
        }
    }
}
