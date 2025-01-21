using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Auditorium
{
    public int AuditoriaId { get; set; }

    public DateTime Fecha { get; set; }

    public int? UsuarioId { get; set; }

    public string TablaAfectada { get; set; } = null!;

    public string TipoAccion { get; set; } = null!;

    public int RegistroId { get; set; }

    public string? ValorAnterior { get; set; }

    public string? ValorNuevo { get; set; }

    public string? Descripcion { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
