using Abstracciones.ModelosBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.AD.Interfaces.Ventas.CrearVenta
{
    public interface ICrearVentaAD
    {
        Task<int> Crear(VentasTabla laVentaAGuardar);
    }
}
