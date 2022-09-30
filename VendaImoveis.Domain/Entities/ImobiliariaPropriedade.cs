namespace VendaImoveis.Domain.Entities
{
    public class ImobiliariaPropriedade
    {
        public int ImobiliariaId { get; set; }
        public virtual Imobiliaria Imobiliaria { get; set; }
        public int PropriedadeId { get; set; }
        public virtual Propriedade Propriedade { get; set; }
    }
}
