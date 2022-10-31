using Microsoft.AspNetCore.Identity;
using VendaImoveis.Domain.Core;

namespace VendaImoveis.Infrastructure.Utils
{
    public static class PasswordHasher
    {
        public static void PasswordHash(Usuario user)
        {
            var passwordHasher = new PasswordHasher<Usuario>();
            user.Senha = passwordHasher.HashPassword(user, user.Senha);
        }

        public static bool ValidPasswordAsync(Usuario user, string modelSenha)
        {
            if (modelSenha == null && user.Senha == null)
                return false;

            var passwordHasher = new PasswordHasher<Usuario>();
            var status = passwordHasher.VerifyHashedPassword(user, user.Senha, modelSenha);
            switch (status)
            {
                case PasswordVerificationResult.Failed:
                    return false;

                case PasswordVerificationResult.Success:
                    return true;

                default:
                    throw new ArgumentNullException("Erro na validação da senha !");
            }
        }
    }
}
