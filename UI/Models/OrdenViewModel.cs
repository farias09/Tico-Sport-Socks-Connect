using Abstracciones.Modelos.Ordenes;
using Abstracciones.Modelos.Productos;
using Abstracciones.Modelos.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class OrdenViewModel
    {
        public OrdenesDto Orden { get; set; }
        public List<ProductosDto> Productos { get; set; }

        public List<DetalleOrdenesDto> Detalles { get; set; } 
        public UsuarioDto Usuario { get; set; }  
    }
}