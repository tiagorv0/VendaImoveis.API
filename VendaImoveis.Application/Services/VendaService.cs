using AutoMapper;
using FluentValidation;
using VendaImoveis.Application.Interfaces;
using VendaImoveis.Application.Params.Params;
using VendaImoveis.Application.Params.Search;
using VendaImoveis.Application.Services.Common;
using VendaImoveis.Application.ViewModels.Venda;
using VendaImoveis.Domain.Entities;
using VendaImoveis.Domain.Interfaces.Common;

namespace VendaImoveis.Application.Services
{
    public class VendaService : 
        CrudService<Venda, RequestVenda, ResponseVenda, VendaParams, VendaSearch>,
        IVendaService
    {
        public VendaService(IBaseRepository<Venda> repository, IMapper mapper, IUnitOfWork unitOfWork, IValidator<RequestVenda> validator) : base(repository, mapper, unitOfWork, validator)
        {
        }
    }
}
