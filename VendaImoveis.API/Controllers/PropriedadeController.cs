using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VendaImoveis.API.Controllers.Abstract;
using VendaImoveis.Application.Interfaces;
using VendaImoveis.Application.Params.Params;
using VendaImoveis.Application.Params.Search;
using VendaImoveis.Application.ViewModels.Enums;
using VendaImoveis.Application.ViewModels.Propriedade;
using VendaImoveis.Domain.Core;
using VendaImoveis.Domain.Entities;
using VendaImoveis.Domain.Entities.Enums;

namespace VendaImoveis.API.Controllers
{
    [Authorize]
    public class PropriedadeController :
        CrudControllerBase<Propriedade, RequestPropriedade, ResponsePropriedade, PropriedadeParams, PropriedadeSearch>
    {
        private readonly IMapper _mapper;
        public PropriedadeController(IPropriedadeService service, IMapper mapper) : base(service)
        {
            _mapper = mapper;
        }

        [HttpGet("tipos-de-propriedade")]
        public virtual IActionResult GetEnumeration()
        {
            return Ok(_mapper.Map<IEnumerable<PropertyTypeViewModel>>(Enumeration.GetAll<PropertyType>()));
        }
    }
}
