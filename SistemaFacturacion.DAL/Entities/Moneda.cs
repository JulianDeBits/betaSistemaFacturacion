using System;
using System.Collections.Generic;

namespace SistemaFacturacion.DAL.Entities;

public partial class Moneda
{
    public int Id { get; set; }

    public string? Codigo { get; set; }

    public string? Nombre { get; set; }

    public string? Simbolo { get; set; }

    public virtual ICollection<Gasto> Gastos { get; set; } = new List<Gasto>();

    public virtual ICollection<Presupuesto> Presupuestos { get; set; } = new List<Presupuesto>();
}
