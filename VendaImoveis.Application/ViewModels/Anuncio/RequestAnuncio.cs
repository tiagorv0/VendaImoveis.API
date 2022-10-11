using VendaImoveis.Application.ViewModels.Propriedade;

namespace VendaImoveis.Application.ViewModels.Anuncio
{
    public class RequestAnuncio
    {
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public int ImobiliariaId { get; set; }
        public RequestPropriedade Propriedade { get; set; }
    }
}
