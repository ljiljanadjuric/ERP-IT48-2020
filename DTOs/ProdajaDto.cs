using ProdavnicaObuce.Models;
using System.ComponentModel.DataAnnotations;

namespace ProdavnicaObuce.DTOs
{
    public class ProdajaDto
    {
        public int Id { get; set; }
        public DateTime VremeProdaje { get; set; }
        public double CenaProdaje { get; set; }
        public string NacinPlacanja { get; set; }
        public string Kupac { get; set; }
        public bool Placeno { get; set; }
    }
}
