using VendaImoveis.Domain.Core;

namespace VendaImoveis.Domain.Entities
{
    public class Anuncio : Registro
    {
        public string Descricao { get; set; }
        public int CorretorId { get; set; }
        public virtual Corretor Corretor { get; set; }
        public int PropriedadeId { get; set; }
        public virtual Propriedade Propriedade { get; set; }
        public virtual IEnumerable<Imobiliaria> Imobiliarias { get; set; }
    }
}
