using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public string? Provincia { get; set; }

    public int? RolId { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<Auditorium> Auditoria { get; set; } = new List<Auditorium>();

    public virtual ICollection<Caja> Cajas { get; set; } = new List<Caja>();

    public virtual ICollection<Mensaje> MensajeEmisors { get; set; } = new List<Mensaje>();

    public virtual ICollection<Mensaje> MensajeReceptors { get; set; } = new List<Mensaje>();

    public virtual ICollection<MovimientosCaja> MovimientosCajas { get; set; } = new List<MovimientosCaja>();

    public virtual ICollection<Reporte> Reportes { get; set; } = new List<Reporte>();

    public virtual Role? Rol { get; set; }

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
