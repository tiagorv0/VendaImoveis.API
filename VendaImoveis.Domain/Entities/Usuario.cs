using VendaImoveis.Domain.Core;
using VendaImoveis.Domain.Entities.Enums;

namespace VendaImoveis.Domain.Entities
{
    public class Usuario : Registro
    {
        public string Nome { get; set; }
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public int TipoUsuarioId { get; set; }
        public UserRole TipoUsuario { get; set; }
    }
}
