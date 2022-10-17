using LinqKit;
using System.Linq.Expressions;
using VendaImoveis.Domain.Entities;

namespace VendaImoveis.Application.Params.Params
{
    public class PropriedadeParams : BaseParams<Propriedade>
    {
        public decimal? AreaTotal { get; set; }
        public decimal? AreaConstruida { get; set; }
        public int? QuantidadeGaragem { get; set; }
        public decimal? Valor { get; set; }
        public int? TipoImovelId { get; set; }
        public bool? FoiVendida { get; set; }

        public override Expression<Func<Propriedade, bool>> Filter()
        {
            var predicate = PredicateBuilder.New<Propriedade>();

            if (AreaTotal.HasValue) predicate = predicate.And(x => x.AreaTotal == AreaTotal);
            if (AreaConstruida.HasValue) predicate = predicate.And(x => x.AreaConstruida == AreaConstruida);
            if (QuantidadeGaragem.HasValue) predicate = predicate.And(x => x.QuantidadeGaragem == QuantidadeGaragem);
            if (Valor.HasValue) predicate = predicate.And(x => x.Valor == Valor);
            if (TipoImovelId.HasValue) predicate = predicate.And(x => x.TipoImovelId == TipoImovelId);
            if (FoiVendida.HasValue) predicate = predicate.And(x => x.FoiVendida == FoiVendida);

            return predicate;
        }
    }
}
