
namespace VendaImoveis.Application.Params.Search
{
    public class PropriedadeSearch : SearchBase
    {
        public decimal AreaTotal { get; set; }
        public decimal AreaConstruida { get; set; }
        public int QuantidadeGaragem { get; set; }
        public decimal Valor { get; set; }
        public int TipoImovelId { get; set; }
        public bool FoiVendida { get; set; }
    }
}
