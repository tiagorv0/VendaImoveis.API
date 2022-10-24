using System.Text.Json.Serialization;

namespace VendaImoveis.Application.ViewModels.Usuario
{
    public class RequestUsuario
    {
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        [JsonIgnore]
        public int TipoUsuarioId { get; set; }
    }
}
