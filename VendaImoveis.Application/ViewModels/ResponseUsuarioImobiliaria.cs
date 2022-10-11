using VendaImoveis.Application.ViewModels.Usuario;

namespace VendaImoveis.Application.ViewModels
{
    public class ResponseUsuarioImobiliaria
    {
        public string Nome { get; set; }
        public string CRECI { get; set; }
        public string Telefone { get; set; }
        public ResponseUsuario Usuario { get; set; }
    }
}
