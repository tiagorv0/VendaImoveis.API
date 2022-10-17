using System.Linq.Expressions;
using VendaImoveis.Domain.Core;
using VendaImoveis.Domain.Core.Params;

namespace VendaImoveis.Application.Params.Params
{
    public abstract class BaseParams<T> : IParams
        where T : Registro
    {
        public int Skip { get; set; }
        public int Take { get; set; } = 5;

        public abstract Expression<Func<T, bool>> Filter();
        protected BaseParams() { }
    }
}
