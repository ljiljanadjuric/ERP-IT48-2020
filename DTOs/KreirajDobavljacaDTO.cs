using System.ComponentModel.DataAnnotations;

namespace ProdavnicaObuce.DTOs
{
    public class KreirajDobavljacaDTO
    {
        [Required, MaxLength(100)]
        public string Ime { get; set; } = String.Empty;
        [Required, MaxLength(100)]
        public string Prezime { get; set; } = String.Empty;
        [Required, MaxLength(100)]
        public string Kontakt { get; set; } = String.Empty;
    }
}
