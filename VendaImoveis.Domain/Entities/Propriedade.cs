using VendaImoveis.Domain.Core;
using VendaImoveis.Domain.Entities.Enums;

namespace VendaImoveis.Domain.Entities
{
    public class Propriedade : Registro
    {
        public string Nome { get; set; }
        public Endereco Endereco { get; set; }
        public decimal AreaTotal { get; set; }
        public decimal AreaConstruida { get; set; }
        public int QuantidadeGaragem { get; set; }
        public decimal Valor { get; set; }
        public int TipoImovelId { get; set; }
        public virtual PropertyType TipoImovel { get; set; }
        public bool FoiVendida { get; set; }
    }
}
