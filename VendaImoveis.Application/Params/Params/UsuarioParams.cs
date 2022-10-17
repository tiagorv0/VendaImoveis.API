using LinqKit;
using System.Linq.Expressions;
using VendaImoveis.Domain.Entities;

namespace VendaImoveis.Application.Params.Params
{
    public class UsuarioParams : BaseParams<Usuario>
    {
        public string? NomeUsuario { get; set; }
        public string? Email { get; set; }

        public override Expression<Func<Usuario, bool>> Filter()
        {
            var predicate = PredicateBuilder.New<Usuario>();

            if (!string.IsNullOrEmpty(NomeUsuario))
                predicate = predicate.And(x => x.NomeUsuario.Contains(NomeUsuario));

            if (!string.IsNullOrEmpty(Email))
                predicate = predicate.And(x => x.Email.Contains(Email));

            return predicate;
        }
    }
}
