using VendaImoveis.Domain.Core;

namespace VendaImoveis.Domain.Entities
{
    public class Corretor : UsuariosImobiliaria
    {
        public string CPF { get; set; }
        public int ImobiliariaId { get; set; }
        public virtual Imobiliaria Imobiliaria { get; set; }
        public virtual IEnumerable<Venda> Vendas { get; set; }

    }
}
