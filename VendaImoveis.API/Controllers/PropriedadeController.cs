using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VendaImoveis.API.Controllers.Abstract;
using VendaImoveis.Application.Constants;
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
    
    public class PropriedadeController :
        CrudControllerBase<Propriedade, RequestPropriedade, ResponsePropriedade, PropriedadeParams, PropriedadeSearch>
    {
        private readonly IMapper _mapper;
        public PropriedadeController(IPropriedadeService service, IMapper mapper) : base(service)
        {
            _mapper = mapper;
        }

        [Authorize(Roles = Roles.Imobiliaria)]
        [HttpGet("tipos-de-propriedade")]
        public virtual IActionResult GetEnumeration()
        {
            return Ok(_mapper.Map<IEnumerable<PropertyTypeViewModel>>(Enumeration.GetAll<PropertyType>()));
        }

        [Authorize(Roles = Roles.Imobiliaria)]
        public override Task<IActionResult> CreateAsync([FromBody] RequestPropriedade request)
        {
            return base.CreateAsync(request);
        }

        [Authorize(Roles = Roles.Imobiliaria)]
        public override Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] RequestPropriedade request)
        {
            return base.UpdateAsync(id, request);
        }

        [Authorize(Roles = Roles.Imobiliaria)]
        public override Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            return base.DeleteAsync(id);
        }
    }
}
