using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VendaImoveis.API.Controllers.Abstract;
using VendaImoveis.Application.Constants;
using VendaImoveis.Application.Interfaces;
using VendaImoveis.Application.Interfaces.Storage;
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

        public PropriedadeController(IPropriedadeService service, 
                                    IMapper mapper
        ) : base(service)
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

        //[HttpPut("img/{id}")]
        //[Authorize(Roles = Roles.Imobiliaria)]
        //public async Task<IActionResult> UploadImagesAsync([FromRoute] int id, IList<IFormFile> images)
        //{
        //    var result = await _propriedadeFileStorageService.UploadManyImgAsync(id, images);
        //    return Ok(result);
        //}

        //[HttpDelete("img/{id}")]
        //[Authorize(Roles = Roles.Imobiliaria)]
        //public async Task<IActionResult> RemoveAllImagesAsync([FromRoute] int id)
        //{
        //    var result = await _propriedadeFileStorageService.RemoveImgAsync(id);
        //    return Ok(result);
        //}

        //[Authorize(Roles = Roles.Imobiliaria)]
        //[HttpDelete("img/{id}")]
        //public async Task<IActionResult> RemoveImageAsync([FromRoute] int id, [FromBody] int index)
        //{
        //    var result = await _propriedadeFileStorageService.RemoveOnlyOneImgAsync(id, index);
        //    return Ok(result);
        //}

        //public IActionResult GetSingleImage([FromRoute] int id, [FromBody] int index)
        //{
        //    var result = _propriedadeFileStorageService.GetImg(id);
        //    return Ok(result);
        //}

        //[HttpGet("img/{id}")]
        //public IActionResult GetAllImages([FromRoute] int id)
        //{
        //    var result = _propriedadeFileStorageService.GetAllImg(id);
        //    return Ok(result);
        //}
    }
}
