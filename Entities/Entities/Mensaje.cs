using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Mensaje
{
    public int MensajeId { get; set; }

    public int? EmisorId { get; set; }

    public int? ReceptorId { get; set; }

    public string Contenido { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public virtual Usuario? Emisor { get; set; }

    public virtual Usuario? Receptor { get; set; }
}
