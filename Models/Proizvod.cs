using System.ComponentModel.DataAnnotations;

namespace ProdavnicaObuce.Models
{
    public class Proizvod : Entitet
    {
        [Required]
        public string Ime { get; set; } = String.Empty;

        [Required]
        public double Cena { get; set; }
        [Required]
        public int Kolicina { get; set; }
        [Required]
        public string Boja { get; set; } = String.Empty;
        [Required]
        public string Brend { get; set; } = String.Empty;

        public virtual List<StavkaProdaje>? StavkeProdaje { get; set; }


    }
}
