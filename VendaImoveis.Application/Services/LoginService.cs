using FluentValidation;
using System.Security.Claims;
using VendaImoveis.Application.Exceptions;
using VendaImoveis.Application.Interfaces;
using VendaImoveis.Application.ViewModels.Login;
using VendaImoveis.Domain.Core;
using VendaImoveis.Domain.Interfaces;
using VendaImoveis.Infrastructure.Utils;

namespace VendaImoveis.Application.Services
{
    public class LoginService : ILoginService
    {
        private readonly ICorretorRepository _corretorRepository;
        private readonly IImobiliariaRepository _imobiliariaRepository;
        private readonly IValidator<LoginViewModel> _validator;

        public LoginService(ICorretorRepository corretorRepository,
            IValidator<LoginViewModel> validator,
            IImobiliariaRepository imobiliariaRepository)
        {
            _corretorRepository = corretorRepository;
            _validator = validator;
            _imobiliariaRepository = imobiliariaRepository;
        }

        public async Task<IEnumerable<Claim>> Login(LoginViewModel model)
        {
            var validation = await _validator.ValidateAsync(model);
            if (!validation.IsValid)
                throw new BadRequestException(validation);

            var user = await GetUser(model);

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

        private async Task<Usuario?> GetUser(LoginViewModel model)
        {
            if (model.Cargo.Equals(Cargo.Imobiliaria))
                return await _imobiliariaRepository.GetFirstAsync(x => x.NomeUsuario == model.NomeUsuario);

            if (model.Cargo.Equals(Cargo.Corretor))
                return await _corretorRepository.GetFirstAsync(x => x.NomeUsuario == model.NomeUsuario);

            throw new BadRequestException(nameof(model.Cargo), "Cargo inválido!");
        }
    }
}
