using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Pago
{
    public int PagoId { get; set; }

    public int? VentaId { get; set; }

    public DateTime Fecha { get; set; }

    public decimal Monto { get; set; }

    public string? MetodoPago { get; set; }

    public string Estado { get; set; } = null!;

    public string? ReferenciaTransaccion { get; set; }

    public int? CajaId { get; set; }

    public virtual Caja? Caja { get; set; }

    public virtual Venta? Venta { get; set; }
}
