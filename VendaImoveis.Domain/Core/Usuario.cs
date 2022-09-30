using VendaImoveis.Domain.Entities;
using VendaImoveis.Domain.Entities.Enums;

namespace VendaImoveis.Domain.Core
{
    public abstract class Usuario : Registro
    {
        public string Nome { get; set; }
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public int TipoUsuarioId { get; set; }
        public virtual UserRole TipoUsuario { get; set; }
        public int ImobiliariaId { get; set; }
        public virtual Imobiliaria Imobiliaria { get; set; }
    }
}
