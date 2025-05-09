using System;
using System.Collections.Generic;

namespace SistemaFacturacion.DAL.Entities;

public partial class Usuario
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Email { get; set; }

    public string? PasswordHash { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Gasto> Gastos { get; set; } = new List<Gasto>();

    public virtual ICollection<Presupuesto> Presupuestos { get; set; } = new List<Presupuesto>();
}
