using VendaImoveis.Application.ViewModels.Usuario;

namespace VendaImoveis.Application.ViewModels.Common
{
    public class RequestUsuariosImobiliaria : RequestUsuario
    {
        public string Nome { get; set; }
        public string CRECI { get; set; }
        public string Telefone { get; set; }
    }
}
