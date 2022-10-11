using System.Linq.Expressions;

namespace VendaImoveis.Domain.Core.Params
{
    public interface IFiltrable<TEntity> : IParams where TEntity : Registro
    {
        Expression<Func<TEntity, bool>> Filter();
    }
}
