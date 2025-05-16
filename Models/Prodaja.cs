using System.ComponentModel.DataAnnotations;

namespace ProdavnicaObuce.Models
{
    public enum NacinPlacanja { Kes = 0, Kartica = 1 }

    public class Prodaja : Entitet
    {
        [Required]
        public DateTime VremeProdaje { get; set; }
        [Required]
        public double CenaProdaje { get; set; }
        [Required]
        public NacinPlacanja NacinPlacanja { get; set; }
        public bool Placeno { get; set; }
        public int IdKupca { get; set; }
        public virtual Korisinik? Kupac { get; set; }

        public virtual List<StavkaProdaje>? StavkeProdaje { get; set; }
    }
}
