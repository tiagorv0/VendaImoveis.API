using VendaImoveis.Domain.Core;

namespace VendaImoveis.Domain.Interfaces.Common
{
    public interface IUsuariosImobiliariaRepository<TEntity> : 
        IBaseRepository<TEntity>
        where TEntity : UsuariosImobiliaria
    {
    }
}
