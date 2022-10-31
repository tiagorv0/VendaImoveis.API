using Microsoft.EntityFrameworkCore;
using VendaImoveis.Domain.Core;
using VendaImoveis.Domain.Interfaces.Common;
using VendaImoveis.Infrastructure.Context;

namespace VendaImoveis.Infrastructure.Repositories.Common
{
    public class BaseRepository<TEntity> : BaseReadOnlyRepository<TEntity>, IBaseRepository<TEntity> where TEntity : Registro
    {
        public BaseRepository(ApplicationContext context) : base(context)
        { }

        public virtual async Task<TEntity> CreateAsync(TEntity model)
        {
            _dbSet.Add(model);

            return model;
        }
        public virtual async Task<TEntity> UpdateAsync(TEntity model)
        {
            model.AtualizadoEm = DateTime.Now;
            _dbSet.Update(model);

            return model;
        }

        public virtual async Task DeleteAsync(int id)
        {
            var obj = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

            _dbSet.Remove(obj);
        }

    }
}
