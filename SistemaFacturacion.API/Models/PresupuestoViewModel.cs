using System.ComponentModel.DataAnnotations;

public class PresupuestoViewModel
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public int CategoriaId { get; set; }

    public int MonedaId { get; set; }

    public decimal? Limite { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

}
