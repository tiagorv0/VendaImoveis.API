using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VendaImoveis.API.Controllers.Abstract;
using VendaImoveis.Application.Constants;
using VendaImoveis.Application.Interfaces;
using VendaImoveis.Application.Interfaces.Storage;
using VendaImoveis.Application.Params.Params;
using VendaImoveis.Application.Params.Search;
using VendaImoveis.Application.ViewModels.Imobiliaria;
using VendaImoveis.Domain.Entities;

namespace VendaImoveis.API.Controllers
{
    public class ImobiliariaController :
        UsuariosImobiliariaControllerBase<Imobiliaria, RequestImobiliaria, ResponseImobiliaria, ImobiliariaParams, ImobiliariaSearch>
    {
        private readonly IImobiliariaFileStorageService _fileStorageService;
        public ImobiliariaController(
            IImobiliariaService service,
            IImobiliariaFileStorageService fileStorageService
        ) : base(service)
        {
            _fileStorageService = fileStorageService;
        }

        [Authorize(Roles = Roles.Imobiliaria)]
        public override Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] RequestImobiliaria request)
        {
            return base.UpdateAsync(id, request);
        }

        [Authorize(Roles = Roles.Imobiliaria)]
        public override Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            return base.DeleteAsync(id);
        }

        [HttpPut("img/{id}")]
        [Authorize(Roles = Roles.Imobiliaria)]
        public async Task<IActionResult> PutImgAsync([FromRoute] int id, IFormFile img)
        {
            var result = await _fileStorageService.UploadLogoAsync(id, img);
            return Ok(result);
        }

        [HttpDelete("img/{id}")]
        [Authorize(Roles = Roles.Imobiliaria)]
        public async Task<IActionResult> DeleteImgAsync([FromRoute] int id)
        {
            var result = await _fileStorageService.RemoveImgAsync(id);
            return Ok(result);
        }

        [HttpGet("img/{id}")]
        [AllowAnonymous]
        public IActionResult GetImg([FromRoute] int id)
        {
            var result = _fileStorageService.GetImg(id);
            return Ok(result);
        }
    }
}
