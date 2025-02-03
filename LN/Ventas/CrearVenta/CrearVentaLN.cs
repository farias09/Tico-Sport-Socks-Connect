using Abstracciones.AD.Interfaces.Ventas.CrearVenta;
using Abstracciones.LN.Interfaces.General.Conversiones.Ventas.ConvertirAVentasTabla;
using Abstracciones.LN.Interfaces.Ventas.CrearVenta;
using Abstracciones.Modelos.Ventas;
using AcessoADatos.Ventas.CrearVenta;
using LN.General.Conversiones.Ventas.ConvertirAVentasTabla;
using LN.Productos.CrearProducto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LN.Ventas.CrearVenta
{
    public class CrearVentaLN : ICrearVentaLN
    {
        private readonly ICrearVentaAD _crearVentaAD;
        private readonly IConvertirAVentasTabla _convertirAVentasTabla;

        public CrearVentaLN(ICrearVentaAD crearVentaAD, IConvertirAVentasTabla convertirAVentasTabla)
        {
            _crearVentaAD = crearVentaAD;
            _convertirAVentasTabla = convertirAVentasTabla;
        }

        public async Task<int> Crear(VentasDto modelo)
        {
            modelo.estado = "1";
            int cantidadDeDatosGuardados = await _crearVentaAD.Crear(_convertirAVentasTabla.ConvertirObjetoAVentasTabla(modelo));
            return cantidadDeDatosGuardados;
        }
    }
}
