using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaFacturacion.DAL.Entities;

public partial class Gasto
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public int CategoriaId { get; set; }

    public int MonedaId { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Monto { get; set; }

    public DateTime Fecha { get; set; }

    [MaxLength(300)]
    [Column(TypeName = "varchar(300)")]
    public string? Descripcion { get; set; }

    public virtual Categoria Categoria { get; set; } = null!;

    public virtual Moneda Moneda { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
