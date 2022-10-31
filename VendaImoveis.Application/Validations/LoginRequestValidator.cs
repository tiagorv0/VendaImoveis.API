using FluentValidation;
using VendaImoveis.Application.Utils;
using VendaImoveis.Application.ViewModels.Login;

namespace VendaImoveis.Application.Validations
{
    public class LoginRequestValidator : AbstractValidator<LoginViewModel>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.NomeUsuario)
                .NotEmpty();

            RuleFor(x => x.Senha)
                .Must(senha => PropertyValidation.SenhaEhValido(senha))
                .WithMessage("Senha deve conter o mínimo de oito caracteres, pelo menos uma letra maiúscula, uma letra minúscula, um número e um caractere especial.")
                .NotEmpty();

            RuleFor(x => x.Cargo)
                .Must(x => x.HasFlag(Cargo.Imobiliaria) || x.HasFlag(Cargo.Corretor))
                .NotEmpty();
        }
    }
}
