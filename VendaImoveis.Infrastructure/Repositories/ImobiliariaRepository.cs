using VendaImoveis.Domain.Entities;
using VendaImoveis.Domain.Interfaces;
using VendaImoveis.Infrastructure.Context;
using VendaImoveis.Infrastructure.Repositories.Common;
using VendaImoveis.Infrastructure.Utils;

namespace VendaImoveis.Infrastructure.Repositories
{
    public class ImobiliariaRepository : BaseRepository<Imobiliaria>, IImobiliariaRepository
    {
        public ImobiliariaRepository(ApplicationContext context):base(context)
        {

        }

        public override Task<Imobiliaria> CreateAsync(Imobiliaria model)
        {
            PasswordHasher.PasswordHash(model.Usuario);
            return base.CreateAsync(model);
        }

        public override Task<Imobiliaria> UpdateAsync(Imobiliaria model)
        {
            PasswordHasher.PasswordHash(model.Usuario);
            return base.UpdateAsync(model);
        }
    }
}
