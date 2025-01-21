using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Reporte
{
    public int ReporteId { get; set; }

    public string TipoReporte { get; set; } = null!;

    public DateTime FechaGeneracion { get; set; }

    public int? UsuarioId { get; set; }

    public string Periodo { get; set; } = null!;

    public string Formato { get; set; } = null!;

    public virtual Usuario? Usuario { get; set; }
}
