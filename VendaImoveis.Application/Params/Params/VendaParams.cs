using System.Linq.Expressions;
using VendaImoveis.Domain.Entities;

namespace VendaImoveis.Application.Params.Params
{
    public class VendaParams : BaseParams<Venda>
    {
        public override Expression<Func<Venda, bool>> Filter()
        {
            throw new NotImplementedException();
        }
    }
}
