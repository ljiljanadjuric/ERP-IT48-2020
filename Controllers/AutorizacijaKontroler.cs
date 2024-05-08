using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProdavnicaObuce.DTOs;
using ProdavnicaObuce.Interface;

namespace ProdavnicaObuce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorizacijaKontroler : ControllerBase
    {
        IAutorizacijaServis _autorizacijaServis;

        public AutorizacijaKontroler(IAutorizacijaServis autorizacijaServis)
        {
            _autorizacijaServis = autorizacijaServis;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var token = await _autorizacijaServis.Login(loginDTO);
            return Ok(token);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] RegisterDTO registerDTO)
        {
            await _autorizacijaServis.Register(registerDTO);
            return Ok();
        }
    }
}
