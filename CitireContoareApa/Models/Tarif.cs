using System.ComponentModel.DataAnnotations;

namespace CitireContoareApa.Models
{
    public class Tarif
    {
        [Key]
        public int TarifId { get; set; }

        [Required]
        public decimal PretPeMetruCub { get; set; }

        [Required]
        public DateTime DataInceput { get; set; }

        public DateTime? DataSfarsit { get; set; } // Optional, poate fi null pentru tariful curent

        public ICollection<Factura>? Facturi { get; set; }
    }
}
