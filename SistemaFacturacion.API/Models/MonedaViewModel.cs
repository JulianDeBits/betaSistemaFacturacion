using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion.API.Models
{
    public class MonedaViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Codigo { get; set; }

        [Required]
        public string Nombre { get; set; }

        public string? Simbolo { get; set; }
    }
}

