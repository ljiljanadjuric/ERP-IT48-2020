using System.ComponentModel.DataAnnotations;

namespace ProdavnicaObuce.Models
{
    public class Porudzbina : Entitet
    {
        [Required]
        public string Status { get; set; } = String.Empty;
        [Required]
        public DateTime VremePorudzbe { get; set; }
        [Required]
        public DateTime VremeDostave { get; set; }
        [Required]
        public double CenaPorudzbine { get; set; }
        public int IdZaposlenog { get; set; }
        public int IdDobavljaca { get; set; }
        
        public virtual Korisinik? Korisinik { get; set; }
        public virtual Dobavljac? Dobavljac { get; set; }
        public virtual List<StavkaPorudzbine>? StavkePorudzbine { get; set; }
    }
}
