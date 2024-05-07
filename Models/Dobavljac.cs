using System.ComponentModel.DataAnnotations;

namespace ProdavnicaObuce.Models
{
    public class Dobavljac : Entitet
    {
        [Required, MaxLength(100)]
        public string Ime { get; set; } = String.Empty;
        [Required, MaxLength(100)]
        public string Prezime { get; set; } = String.Empty;
        [Required, MaxLength(100)]
        public string Kontakt { get; set; } = String.Empty;
        public virtual List<Porudzbina>? Porudzbine { get; set; }

    }
}
