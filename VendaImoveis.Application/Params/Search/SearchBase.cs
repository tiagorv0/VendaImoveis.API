using VendaImoveis.Domain.Core.Params;

namespace VendaImoveis.Application.Params.Search
{
    public abstract class SearchBase : ISearch
    {
        public int? Limit { get; set; }
        public int? Offset { get; set; }
        public string? Sort { get; set; }
    }
}
