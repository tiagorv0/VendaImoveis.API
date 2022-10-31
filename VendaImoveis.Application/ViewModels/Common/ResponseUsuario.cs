using VendaImoveis.Application.ViewModels.Enums;
using VendaImoveis.Domain.Core;

namespace VendaImoveis.Application.ViewModels.Usuario
{
    public class ResponseUsuario : Registro
    {
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public UserRoleViewModel TipoUsuario { get; set; }
    }
}
