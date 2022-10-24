namespace VendaImoveis.Application.Params.Search
{
    public class UsuarioSearch : SearchBase
    {
        public string? NomeUsuario { get; set; }
        public string? Email { get; set; }
    }
}
