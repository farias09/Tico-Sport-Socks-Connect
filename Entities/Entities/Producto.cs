using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Producto
{
    public int ProductoId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    public int? Stock { get; set; }

    public string? Imagen { get; set; }

    public int? CategoriaId { get; set; }

    public virtual ICollection<Carrito> Carritos { get; set; } = new List<Carrito>();

    public virtual Categoria? Categoria { get; set; }
}
