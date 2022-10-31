using VendaImoveis.Application.ViewModels.Enums;
using VendaImoveis.Application.ViewModels.Usuario;
using VendaImoveis.Domain.Core;

namespace VendaImoveis.Application.ViewModels.Common
{
    public class ResponseUsuariosImobiliaria : ResponseUsuario
    {
        public string Nome { get; set; }
        public string CRECI { get; set; }
        public string Telefone { get; set; }
    }
}
