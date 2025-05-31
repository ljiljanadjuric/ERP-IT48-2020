using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProdavnicaObuce.Models
{
    public class Proizvod : Entitet
    {
        [Required]
        public string Ime { get; set; } = String.Empty;

        [Required]
        public double Cena { get; set; }
        [NotMapped]
        public double ProdajnaCena
        {
            get
            {
                return Math.Round(Cena * 1.15, 2);
            }
            private set
            {
                ProdajnaCena = value;
            }
        }
        [Required]
        public int Kolicina { get; set; }
        [Required]
        public string Boja { get; set; } = String.Empty;
        [Required]
        public string Brend { get; set; } = String.Empty;
        [Required]
        public string Slika { get; set; } = String.Empty;

        public virtual List<StavkaProdaje>? StavkeProdaje { get; set; }
        public virtual List<StavkaPorudzbine>? StavkePorudzbine { get; set; }


    }
}
