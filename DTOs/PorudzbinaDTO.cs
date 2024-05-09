namespace ProdavnicaObuce.DTOs
{
    public class PorudzbinaDTO
    {
        public int IdDobavljaca { get; set; }
        public List<StavkaPorudzbineDTO> StavkePorudzbine { get; set; } = new List<StavkaPorudzbineDTO>();
    }
}
