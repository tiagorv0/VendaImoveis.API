using VendaImoveis.Domain.Entities.Enums;

namespace VendaImoveis.Domain.Core
{
    public abstract class Usuario : Registro
    {
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int TipoUsuarioId { get; set; }
        public virtual UserRole TipoUsuario { get; set; }
    }
}
