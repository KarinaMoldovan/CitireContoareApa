using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CitireContoareApa.Models
{
    public class Contor
    {
        [Key]
        public int ContorId { get; set; }

        [Required]
        [StringLength(50)]
        public string NumarSerie { get; set; }

        [Required]
        public decimal ValoareActuala { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }

        public ICollection<Factura>? Facturi { get; set; }
    }
}
