using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion.API.Models
{
    public class GastoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El usuario es obligatorio.")]
        [Display(Name = "Usuario")]
        public int? UsuarioId { get; set; }

        [Display(Name = "Usuario")]
        public string? UsuarioNombre { get; set; }

        [Required(ErrorMessage = "La categoría es obligatoria.")]
        [Display(Name = "Categoría")]
        public int? CategoriaId { get; set; }

        [Display(Name = "Categoría")]
        public string? CategoriaNombre { get; set; }

        [Required(ErrorMessage = "La moneda es obligatoria.")]
        [Display(Name = "Moneda")]
        public int? MonedaId { get; set; }

        [Display(Name = "Moneda")]
        public string? MonedaNombre { get; set; }

        [Required(ErrorMessage = "El monto es obligatorio.")]
        [Range(0.01, 1000000, ErrorMessage = "El monto debe ser mayor a 0.")]
        [Display(Name = "Monto")]
        public decimal Monto { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria.")]
        [Display(Name = "Fecha")]
        public DateTime Fecha { get; set; }

        [StringLength(300, ErrorMessage = "La descripción no puede superar los 300 caracteres.")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
    }
}
