using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CitireContoareApa.Models
{
    public class User 
    {
        [Key]
        public int UserId { get; set; }

        [StringLength(100)]
        public string ?Nume { get; set; }

        [StringLength(100)]
        public string ?Prenume { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public ICollection<Contor>? Contoare { get; set; }
    }
}
