using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProdavnicaObuce.DTOs;
using ProdavnicaObuce.Interface;
using ProdavnicaObuce.Services;

namespace ProdavnicaObuce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZaposleniController : ControllerBase
    {
        IZaposleniServis _zaposleniServis;

        public ZaposleniController(IZaposleniServis zaposleniServis)
        {
            _zaposleniServis = zaposleniServis;
        }

        [HttpGet("products")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetProizvode()
        {
            var proizvodi = await _zaposleniServis.GetProizvode();
            return Ok(proizvodi);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("products")]
        public async Task<IActionResult> DodajProizvod([FromForm] KreirajProizvodDTO kreirajProizvodDTO)
        {
            if (!int.TryParse(User.Claims.First(c => c.Type == "Id").Value, out int userId))
                throw new Exception("Bad ID. Logout and login.");

            await _zaposleniServis.KreirajProizvod(kreirajProizvodDTO);
            return Ok();
        }
    }
}
