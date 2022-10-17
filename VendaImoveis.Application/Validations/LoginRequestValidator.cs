using FluentValidation;
using VendaImoveis.Application.ViewModels.Login;

namespace VendaImoveis.Application.Validations
{
    public class LoginRequestValidator : AbstractValidator<LoginViewModel>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.NomeUsuario).NotEmpty();
            RuleFor(x => x.Senha).NotEmpty();
        }
    }
}
