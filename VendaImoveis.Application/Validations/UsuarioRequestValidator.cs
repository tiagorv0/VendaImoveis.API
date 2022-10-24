using FluentValidation;
using VendaImoveis.Application.Utils;
using VendaImoveis.Application.ViewModels.Usuario;
using VendaImoveis.Domain.Core;
using VendaImoveis.Domain.Entities.Enums;
using VendaImoveis.Domain.Interfaces;

namespace VendaImoveis.Application.Validations
{
    public class UsuarioRequestValidator : AbstractValidator<RequestUsuario>
    {
        public UsuarioRequestValidator(IUsuarioRepository usuarioRepository)
        {
            RuleFor(x => x.NomeUsuario)
                .MinimumLength(5)
                .MaximumLength(15)
                .NotEmpty();

            RuleFor(x => x.NomeUsuario)
                .Must(username => !usuarioRepository.ExistAsync(x => x.NomeUsuario.Equals(username)).Result)
                .WithMessage("{PropertyName} Já existe um usuário com usuário informado.");

            RuleFor(x => x.Email)
                .EmailAddress()
                .NotEmpty();

            RuleFor(x => x.Email)
                .Must(email => !usuarioRepository.ExistAsync(x => x.Email.Equals(email)).Result)
                .WithMessage("{PropertyName} Já existe um usuário com e-mail informado.");

            RuleFor(x => x.Senha)
                .MinimumLength(8)
                .MaximumLength(20)
                .NotEmpty();

            RuleFor(x => x.Senha)
                .Must(senha => RegexValidate.SenhaEhValido(senha))
                .WithMessage("Senha deve conter o mínimo de oito caracteres, pelo menos uma letra maiúscula, uma letra minúscula, um número e um caractere especial.");

            RuleFor(x => x.TipoUsuarioId)
                .Must(type => Enumeration.GetAll<UserRole>().Any(x => x.Id == type))
                .WithMessage("Tipo do usuário inválido");
        }
    }
}
