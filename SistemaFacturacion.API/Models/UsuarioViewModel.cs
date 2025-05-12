using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion.API.Models
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public DateTime FechaRegistro { get; set; }
    }
}


