using System.ComponentModel.DataAnnotations;

public class CategoriaViewModel
{
    public int Id { get; set; }

    [Required]
    public string Nombre { get; set; }

    public string? Descripcion { get; set; }
}
