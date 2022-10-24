using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VendaImoveis.Domain.Entities;
using VendaImoveis.Domain.Interfaces;
using VendaImoveis.Infrastructure.Context;
using VendaImoveis.Infrastructure.Repositories.Common;

namespace VendaImoveis.Infrastructure.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ApplicationContext context) : base(context)
        {
        }

        public override async Task<Usuario> GetFirstAsync(Expression<Func<Usuario, bool>> filter)
        {
            return await GetQueryable(filter).Include(x => x.TipoUsuario).FirstOrDefaultAsync();
        }
    }
}
