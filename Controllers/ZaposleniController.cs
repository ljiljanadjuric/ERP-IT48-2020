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

        [HttpGet("porudzbine")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PregledajSvePorudzbine()
        {
            var porudzbine = await _zaposleniServis.PregledajSvePorudzbine();
            return Ok(porudzbine);
        }

        [HttpGet("porudzbine-za-prijem")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PregledajPorudzbineKojeCekajuDaSePreuzmu()
        {
            var porudzbine = await _zaposleniServis.PregledajPorudzbineKojeCekajuDaSePreuzmu();
            return Ok(porudzbine);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("proizvodi")]
        public async Task<IActionResult> DodajProizvod([FromForm] KreirajProizvodDTO kreirajProizvodDTO)
        {
            if (!int.TryParse(User.Claims.First(c => c.Type == "Id").Value, out int userId))
                throw new Exception("Bad ID. Logout and login.");

            await _zaposleniServis.KreirajProizvod(kreirajProizvodDTO);
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("dobavljaci")]
        public async Task<IActionResult> DodajDobavljaca([FromForm] KreirajDobavljacaDTO kreirajdobavljacaDTO)
        {
            if (!int.TryParse(User.Claims.First(c => c.Type == "Id").Value, out int userId))
                throw new Exception("Bad ID. Logout and login.");

            await _zaposleniServis.KreirajDobavljaca(kreirajdobavljacaDTO);
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpPatch("proizvodi")]
        public async Task<IActionResult> PoruciProizvode(PorudzbinaDTO porudzbina)
        {
            if (!int.TryParse(User.Claims.First(c => c.Type == "Id").Value, out int userId))
                throw new Exception("Bad ID. Logout and login.");

            await _zaposleniServis.PoruciProizvode(porudzbina, userId);
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpPatch("porudzbine")]
        public async Task<IActionResult> PreuzmiPorudzbinu(int idPorudzbine)
        {
            await _zaposleniServis.PreuzmiPorudzbinu(idPorudzbine);
            return Ok();
        }
    }
}
