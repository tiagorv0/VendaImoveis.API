using VendaImoveis.Domain.Entities;
using VendaImoveis.Domain.Interfaces;
using VendaImoveis.Infrastructure.Context;
using VendaImoveis.Infrastructure.Repositories.Common;

namespace VendaImoveis.Infrastructure.Repositories
{
    public class CorretorRepository : UsuariosImobiliariaRepository<Corretor>, ICorretorRepository
    {
        public CorretorRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
