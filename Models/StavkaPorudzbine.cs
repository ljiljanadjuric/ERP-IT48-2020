using System.ComponentModel.DataAnnotations;

namespace ProdavnicaObuce.Models
{
    public class StavkaPorudzbine : Entitet
    {
        [Required]
        public int Kolicina { get; set; }
        public int IdPorudzbine { get; set; }
        public int IdProizvoda { get; set; }

        public virtual Proizvod? Proizvod { get; set; }
        public virtual Porudzbina? Porudzbina { get; set; }
    }
}
