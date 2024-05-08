using ProdavnicaObuce.Models;
using System.ComponentModel.DataAnnotations;

namespace ProdavnicaObuce.DTOs
{
    public class RegisterDTO
    {
        [Required, MaxLength(100), RegularExpression("[a-zA-Z0-9]+")]
        public string KorisnickoIme { get; set; } = String.Empty;
        [Required, MaxLength(300)]
        public string Sifra { get; set; } = String.Empty;
        [Required, MaxLength(100), EmailAddress]
        public string Email { get; set; } = String.Empty;
        [Required, MaxLength(100)]
        public string Ime { get; set; } = String.Empty;
        [Required, MaxLength(100)]
        public string Prezime { get; set; } = String.Empty;
        [Required, MaxLength(200)]
        public string Adresa { get; set; } = String.Empty;
        [Required, MaxLength(100)]
        public string BrojTelefona { get; set; } = String.Empty;

        [Required]
        public TipKorisnika Tip { get; set; }
    }
}
