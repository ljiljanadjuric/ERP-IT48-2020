using System.ComponentModel.DataAnnotations;

namespace ProdavnicaObuce.DTOs
{
    public class PorudzbinaStanjeDTO
    {
        public int Id { get; set; }
        public int IdDobavljaca { get; set; }
        public string Status { get; set; } = String.Empty;
        public DateTime VremePorudzbe { get; set; }
        public DateTime VremeDostave { get; set; }
        public double CenaPorudzbine { get; set; }
        public List<StavkaPorudzbineDTO> StavkePorudzbine { get; set; } = new List<StavkaPorudzbineDTO>();
    }
}
