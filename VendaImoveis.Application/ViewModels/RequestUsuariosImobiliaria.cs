using VendaImoveis.Application.ViewModels.Usuario;

namespace VendaImoveis.Application.ViewModels
{
    public class RequestUsuariosImobiliaria
    {
        public string Nome { get; set; }
        public string CRECI { get; set; }
        public string Telefone { get; set; }
        public RequestUsuario Usuario { get; set; }
    }
}
