using Abstracciones.AD.Interfaces.Productos.ActualizarProducto;
using Abstracciones.ModelosBaseDeDatos;
using AccesoADatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoADatos.Productos.ActualizarProducto
{
    public class ActualizarProductoAD : IActualizarProductoAD
    {
        Contexto _elContexto;

        public ActualizarProductoAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Editar(ProductosTabla elProductoParaActualizar)
        {
            ProductosTabla elProductoEnBD = _elContexto.ProductosTabla.Where(elProducto => elProducto.Producto_ID == elProductoParaActualizar.Producto_ID).FirstOrDefault();

            elProductoEnBD.nombre = elProductoParaActualizar.nombre;
            elProductoEnBD.descripcion = elProductoParaActualizar.descripcion;
            elProductoEnBD.precio = elProductoParaActualizar.precio;
            elProductoEnBD.stock = elProductoParaActualizar.stock;
            elProductoEnBD.imagen = elProductoParaActualizar.imagen;
            elProductoEnBD.Producto_ID = elProductoParaActualizar.Producto_ID;


            EntityState estado = _elContexto.Entry(elProductoEnBD).State = System.Data.Entity.EntityState.Modified;
            int cantidadDeDatosAlmacenados = await _elContexto.SaveChangesAsync();
            return cantidadDeDatosAlmacenados;
        }
    }
}
