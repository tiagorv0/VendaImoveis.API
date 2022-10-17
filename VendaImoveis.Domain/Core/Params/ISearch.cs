using AspNetCore.IQueryable.Extensions;
using AspNetCore.IQueryable.Extensions.Pagination;
using AspNetCore.IQueryable.Extensions.Sort;

namespace VendaImoveis.Domain.Core.Params
{
    public interface ISearch : 
        ICustomQueryable, IQueryPaging, IQuerySort
    {
    }
}
