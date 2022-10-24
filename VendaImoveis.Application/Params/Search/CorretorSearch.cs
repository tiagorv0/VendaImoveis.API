

namespace VendaImoveis.Application.Params.Search
{
    public class CorretorSearch : SearchBase
    {
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public int? ImobiliariaId { get; set; }
    }
}
