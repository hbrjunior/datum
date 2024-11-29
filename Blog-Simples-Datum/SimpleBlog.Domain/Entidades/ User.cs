using System.ComponentModel.DataAnnotations;

namespace SimpleBlog.Domain.Entidades
{
    public class User
    {
        public int Id { get; set; } // Gerado automaticamente

        [Required]
        [MaxLength(50)] 
        public required string Username { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [MaxLength(255)]
        public required string PasswordHash { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now; // Valor padrão

        public DateTime? UpdatedAt { get; set; }
    }
}
