using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VendaImoveis.Domain.Core;
using VendaImoveis.Domain.Interfaces.Common;
using VendaImoveis.Infrastructure.Context;
using VendaImoveis.Infrastructure.Utils;

namespace VendaImoveis.Infrastructure.Repositories.Common
{
    public class UsuariosImobiliariaRepository<TEntity> : BaseRepository<TEntity>, IUsuariosImobiliariaRepository<TEntity>
        where TEntity : Usuario
    {
        public UsuariosImobiliariaRepository(ApplicationContext context) : base(context)
        {
        }

        public override Task<TEntity> CreateAsync(TEntity model)
        {
            PasswordHasher.PasswordHash(model);
            return base.CreateAsync(model);
        }

        public override Task<TEntity> UpdateAsync(TEntity model)
        {
            PasswordHasher.PasswordHash(model);
            return base.UpdateAsync(model);
        }

        public async override Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await GetQueryable(filter).Include(x => x.TipoUsuario).FirstOrDefaultAsync();
        }
    }
}
