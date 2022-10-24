using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VendaImoveis.Application.Interfaces;
using VendaImoveis.Application.Token;
using VendaImoveis.Application.ViewModels.Login;

namespace VendaImoveis.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _service;
        private readonly ITokenGenerator _tokenGenerator;

        public LoginController(ILoginService service, ITokenGenerator tokenGenerator)
        {
            _service = service;
            _tokenGenerator = tokenGenerator;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            var obj = await _service.Login(model);

            return Ok(new
            {
                token = _tokenGenerator.GenerateToken(obj)
            });
        }
    }
}
