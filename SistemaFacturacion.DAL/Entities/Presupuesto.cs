﻿using System;
using System.Collections.Generic;

namespace SistemaFacturacion.DAL.Entities;

public partial class Presupuesto
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public int CategoriaId { get; set; }

    public int MonedaId { get; set; }

    public decimal? Limite { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public Usuario? Usuario { get; set; }
    public Categoria? Categoria { get; set; }
    public Moneda? Moneda { get; set; }
}
