using VendaImoveis.Application.ViewModels.Endereco;
using VendaImoveis.Application.ViewModels.Enums;
using VendaImoveis.Domain.Core;

namespace VendaImoveis.Application.ViewModels.Propriedade
{
    public class ResponsePropriedade : Registro
    {
        public string Nome { get; set; }
        public EnderecoViewModel Endereco { get; set; }
        public decimal AreaTotal { get; set; }
        public decimal? AreaConstruida { get; set; }
        public int? QuantidadeGaragem { get; set; }
        public decimal Valor { get; set; }
        public PropertyTypeViewModel TipoImovel { get; set; }
        public bool FoiVendida { get; set; }
    }
}
