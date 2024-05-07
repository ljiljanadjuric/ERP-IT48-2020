using System.ComponentModel.DataAnnotations;

namespace ProdavnicaObuce.Models
{
    public class StavkaProdaje : Entitet
    {
        [Required]
        public int Kolicina { get; set; }
        [Required]
        public int IdProizvoda { get; set; }
        [Required]
        public int IdProdaje { get; set; }
        [Required]
        public virtual Prodaja? Prodaja { get; set; }
        [Required]
        public virtual Proizvod? Proizvod { get; set; }
    }
}
