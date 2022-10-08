using VendaImoveis.Domain.Entities;
using VendaImoveis.Domain.Interfaces;
using VendaImoveis.Infrastructure.Context;
using VendaImoveis.Infrastructure.Repositories.Common;

namespace VendaImoveis.Infrastructure.Repositories
{
    public class AnuncioRepository : BaseRepository<Anuncio>, IAnuncioRepository
    {
        public AnuncioRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
