using System.ComponentModel.DataAnnotations;

namespace VolsWebApp.Models
{
    public class Vol
    {
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Prevu { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? Révisé { get; set; }
        public string Compagnie { get; set; }
        public string Provenance { get; set; }
        public string? Etat { get; set; }
    }
}
