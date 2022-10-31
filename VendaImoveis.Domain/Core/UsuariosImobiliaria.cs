using VendaImoveis.Domain.Entities.Enums;

namespace VendaImoveis.Domain.Core
{
    public abstract class UsuariosImobiliaria : Usuario
    {
        public string Nome { get; set; }
        public string CRECI { get; set; }
        public string Telefone { get; set; }
    }
}
