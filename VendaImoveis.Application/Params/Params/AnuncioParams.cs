using LinqKit;
using System.Linq.Expressions;
using VendaImoveis.Domain.Entities;

namespace VendaImoveis.Application.Params.Params
{
    public class AnuncioParams : BaseParams<Anuncio>
    {
        public bool? Ativo { get; set; }
        public int? ImobiliariaId { get; set; }
        public int? PropriedadeId { get; set; }

        public override Expression<Func<Anuncio, bool>> Filter()
        {
            var predicate = PredicateBuilder.New<Anuncio>();

            if (Ativo.HasValue) predicate = predicate.And(x => x.Ativo == Ativo);
            if (ImobiliariaId.HasValue) predicate = predicate.And(x => x.ImobiliariaId == ImobiliariaId);
            if (PropriedadeId.HasValue) predicate = predicate.And(x => x.PropriedadeId == PropriedadeId);

            return predicate;
        }
    }
}
