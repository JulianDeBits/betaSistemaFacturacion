using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion.API.Models
{
    public class PresupuestoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El usuario es obligatorio.")]
        [Display(Name = "Usuario")]
        public int? UsuarioId { get; set; }

        [Display(Name = "Usuario")]
        public string? UsuarioNombre { get; set; }

        [Required(ErrorMessage = "La Categoria es obligatoria.")]
        [Display(Name = "Categoria")]
        public int? CategoriaId { get; set; }

        [Display(Name = "Categoría")]
        public string? CategoriaNombre { get; set; }

        [Required(ErrorMessage = "La Moneda es obligatoria.")]
        [Display(Name = "Moneda")]
        public int? MonedaId { get; set; }

        [Display(Name = "Moneda")]
        public string? MonedaNombre { get; set; }

        public decimal? Limite { get; set; }

        public DateTime? FechaInicio { get; set; }

        public DateTime? FechaFin { get; set; }

    }
}

