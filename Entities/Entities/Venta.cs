using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Venta
{
    public int VentaId { get; set; }

    public DateTime Fecha { get; set; }

    public decimal Subtotal { get; set; }

    public decimal Total { get; set; }

    public int? UsuarioId { get; set; }

    public int? CajaId { get; set; }

    public string? Estado { get; set; }

    public virtual Caja? Caja { get; set; }

    public virtual ICollection<Carrito> Carritos { get; set; } = new List<Carrito>();

    public virtual ICollection<MovimientosCaja> MovimientosCajas { get; set; } = new List<MovimientosCaja>();

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();

    public virtual Usuario? Usuario { get; set; }
}
