using VendaImoveis.Domain.Entities;

namespace VendaImoveis.Domain.Core
{
    public abstract class UsuariosImobiliaria : Registro
    {
        public string Nome { get; set; }
        public string CRECI { get; set; }
        public string Telefone { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
