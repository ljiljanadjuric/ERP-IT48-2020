using ProdavnicaObuce.Models;
using System.ComponentModel.DataAnnotations;

namespace ProdavnicaObuce.DTOs
{
    public class KupiProizvodDTO
    {
        [EnumDataType(typeof(NacinPlacanja))]
        public NacinPlacanja NacinPlacanja { get; set; }
        public List<StavkaKupovineDTO> StavkeProdaje { get; set; } = new List<StavkaKupovineDTO>();
    }
}
