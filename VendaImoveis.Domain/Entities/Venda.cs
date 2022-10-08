using VendaImoveis.Domain.Core;

namespace VendaImoveis.Domain.Entities
{
    public class Venda : Registro
    {
        public int AnuncioId { get; set; }
        public virtual Anuncio Anuncio { get; set; }
        public int CorretorId { get; set; }
        public virtual Corretor Corretor { get; set; }
    }
}
