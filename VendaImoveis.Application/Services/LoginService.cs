using FluentValidation;
using System.Security.Claims;
using VendaImoveis.Application.Exceptions;
using VendaImoveis.Application.Interfaces;
using VendaImoveis.Application.ViewModels.Login;
using VendaImoveis.Domain.Interfaces;
using VendaImoveis.Infrastructure.Utils;

namespace VendaImoveis.Application.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IValidator<LoginViewModel> _validator;

        public LoginService(IUsuarioRepository usuarioRepository, IValidator<LoginViewModel> validator)
        {
            _usuarioRepository = usuarioRepository;
            _validator = validator;
        }

        public async Task<IEnumerable<Claim>> Login(LoginViewModel model)
        {
            var validation = await _validator.ValidateAsync(model);
            if (!validation.IsValid)
                throw new BadRequestException(validation);

            var user = await _usuarioRepository.GetFirstAsync(x => x.NomeUsuario == model.NomeUsuario);

            if (user == null)
                throw new BadRequestException(nameof(model.NomeUsuario), "Usuário ou Senha inválidos");

            if (!PasswordHasher.ValidPasswordAsync(user, model.Senha))
                throw new BadRequestException(nameof(model.Senha), "Usuário ou Senha inválidos");

            return new List<Claim>()
            {
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.NomeUsuario),
                new Claim(ClaimTypes.Role, user.TipoUsuario.Name),
            };
        }
    }
}
