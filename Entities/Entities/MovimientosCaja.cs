using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class MovimientosCaja
{
    public int MovimientoCajaId { get; set; }

    public int? CajaId { get; set; }

    public DateTime Fecha { get; set; }

    public string TipoMovimiento { get; set; } = null!;

    public decimal Monto { get; set; }

    public string? Descripcion { get; set; }

    public int? VentaId { get; set; }

    public int? UsuarioId { get; set; }

    public virtual Caja? Caja { get; set; }

    public virtual Usuario? Usuario { get; set; }

    public virtual Venta? Venta { get; set; }
}
