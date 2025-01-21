using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Caja
{
    public int CajaId { get; set; }

    public DateTime FechaApertura { get; set; }

    public DateTime? FechaCierre { get; set; }

    public decimal MontoInicial { get; set; }

    public decimal? MontoFinal { get; set; }

    public decimal? TotalVentas { get; set; }

    public decimal? TotalGastos { get; set; }

    public string? Estado { get; set; }

    public int? UsuarioId { get; set; }

    public virtual ICollection<MovimientosCaja> MovimientosCajas { get; set; } = new List<MovimientosCaja>();

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();

    public virtual Usuario? Usuario { get; set; }

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
