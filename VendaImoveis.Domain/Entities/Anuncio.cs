using VendaImoveis.Domain.Core;

namespace VendaImoveis.Domain.Entities
{
    public class Anuncio : Registro
    {
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public int ImobiliariaId { get; set; }
        public virtual Imobiliaria Imobiliaria { get; set; }
        public int PropriedadeId { get; set; }
        public virtual Propriedade Propriedade { get; set; }
    }
}
