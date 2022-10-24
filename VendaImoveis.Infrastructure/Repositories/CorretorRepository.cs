using VendaImoveis.Domain.Entities;
using VendaImoveis.Domain.Interfaces;
using VendaImoveis.Infrastructure.Context;
using VendaImoveis.Infrastructure.Repositories.Common;
using VendaImoveis.Infrastructure.Utils;

namespace VendaImoveis.Infrastructure.Repositories
{
    public class CorretorRepository : BaseRepository<Corretor>, ICorretorRepository
    {
        public CorretorRepository(ApplicationContext context) : base(context)
        {
        }

        public override Task<Corretor> CreateAsync(Corretor model)
        {
            PasswordHasher.PasswordHash(model.Usuario);
            return base.CreateAsync(model);
        }

        public override Task<Corretor> UpdateAsync(Corretor model)
        {
            PasswordHasher.PasswordHash(model.Usuario);
            return base.UpdateAsync(model);
        }
    }
}
