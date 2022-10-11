using VendaImoveis.Domain.Core.Params;

namespace VendaImoveis.Domain.Core.Common
{
    public class Pagination : IPaginavel
    {
        public int? Skip { get; set; }
        public int? Take { get; set; }

        public Pagination()
        {
            Take = 10;
        }
    }
}
