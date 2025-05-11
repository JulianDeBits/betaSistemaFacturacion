using System.ComponentModel.DataAnnotations;

public class GastoViewModel
{
    public int Id { get; set; }

    [Required]
    public int PresupuestoId { get; set; }

    [Required]
    public int CategoriaId { get; set; }

    [Required]
    [Range(0, double.MaxValue)]
    public decimal Monto { get; set; }





    public string? Descripcion { get; set; }

    [Required]
    public DateTime Fecha { get; set; }
}
