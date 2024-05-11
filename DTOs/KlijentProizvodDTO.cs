using System.ComponentModel.DataAnnotations;

namespace ProdavnicaObuce.DTOs
{
    public class KlijentProizvodDTO
    {
        [Required]
        public string Ime { get; set; } = String.Empty;
        [Required]
        public double ProdajnaCena { get; set; }
        [Required]
        public int Kolicina { get; set; }
        [Required]
        public string Boja { get; set; } = String.Empty;
        [Required]
        public string Brend { get; set; } = String.Empty;
    }
}
