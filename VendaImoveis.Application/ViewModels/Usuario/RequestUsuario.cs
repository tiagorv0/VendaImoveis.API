namespace VendaImoveis.Application.ViewModels.Usuario
{
    public class RequestUsuario
    {
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int TipoUsuarioId { get; set; }
    }
}
