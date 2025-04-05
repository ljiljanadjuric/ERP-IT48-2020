using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProdavnicaObuce.DTOs;
using ProdavnicaObuce.Interface;

namespace ProdavnicaObuce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorizacijaController : ControllerBase
    {
        IAutorizacijaServis _autorizacijaServis;

        public AutorizacijaController(IAutorizacijaServis autorizacijaServis)
        {
            _autorizacijaServis = autorizacijaServis;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDto>> Login(LoginDTO loginDTO)
        {
            var response = await _autorizacijaServis.Login(loginDTO);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            await _autorizacijaServis.Register(registerDTO);
            return Ok();
        }
    }
}
