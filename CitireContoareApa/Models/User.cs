using System.ComponentModel.DataAnnotations;

namespace CitireContoareApa.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nume { get; set; }

        [Required]
        [StringLength(100)]
        public string Prenume { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public ICollection<Contor>? Contoare { get; set; }
    }
}
