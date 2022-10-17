using VendaImoveis.Application.ViewModels.Anuncio;
using VendaImoveis.Application.ViewModels.Endereco;

namespace VendaImoveis.Application.ViewModels.Propriedade
{
    public class RequestPropriedade
    {
        public string Nome { get; set; }
        public EnderecoViewModel Endereco { get; set; }
        public decimal AreaTotal { get; set; }
        public decimal? AreaConstruida { get; set; }
        public int? QuantidadeGaragem { get; set; }
        public decimal Valor { get; set; }
        public int TipoImovelId { get; set; }
        public bool FoiVendida { get; set; }
    }
}
