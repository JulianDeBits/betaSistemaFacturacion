using System;
using System.Collections.Generic;

namespace SistemaFacturacion.DAL.Entities;

public partial class Gasto
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public int PresupuestoId { get; set; }

    public int CategoriaId { get; set; }

    public int MonedaId { get; set; }

    public decimal Monto { get; set; }

    public DateTime Fecha { get; set; }

    public string? Descripcion { get; set; }

    public virtual Categoria Categoria { get; set; } = null!;

    public virtual Moneda Moneda { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
