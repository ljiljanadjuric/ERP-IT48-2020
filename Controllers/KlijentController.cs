using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProdavnicaObuce.DTOs;
using ProdavnicaObuce.Interface;

namespace ProdavnicaObuce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KlijentController : ControllerBase
    {
        IKlijentServis _klijentServis;

        public KlijentController(IKlijentServis klijentServis)
        {
            _klijentServis = klijentServis;
        }

        [HttpGet("products")]
        [Authorize(Roles = "Klijent")]
        public async Task<IActionResult> GetProizvode()
        {
            var proizvodi = await _klijentServis.GetProizvode();
            return Ok(proizvodi);
        }
        
        [HttpGet("filtirrani-proizvodi")]
        [Authorize(Roles = "Klijent")]
        public async Task<IActionResult> FiltrirajProizvode(double? cena, string? boja, string? brend)
        {
            var proizvodi = await _klijentServis.FiltrirajProizvode(cena, boja, brend);
            return Ok(proizvodi);
        }

        [HttpPost("Cash")]
        [Authorize(Roles = "Klijent")]
        public async Task<IActionResult> KupiProizvodeKes(KupiProizvodDTO kupiProizvodDTO)
        {
            if (!int.TryParse(User.Claims.First(c => c.Type == "Id").Value, out int userId))
                throw new Exception("Bad ID. Logout and login.");
            await _klijentServis.KupiProizvodeKes(kupiProizvodDTO, userId);
            return Ok();
        }

        [HttpPost("Card")]
        [Authorize(Roles = "Klijent")]
        public async Task<ActionResult<CardPaymentDto>> KupiProizvodeKartica(KupiProizvodDTO kupiProizvodDTO)
        {
            if (!int.TryParse(User.Claims.First(c => c.Type == "Id").Value, out int userId))
                throw new Exception("Bad ID. Logout and login.");
            var sessionKey = await _klijentServis.KupiProizvodeKartica(kupiProizvodDTO, userId);
            return Ok(new CardPaymentDto {
                SessionId = sessionKey
            });
        }
    }
}
