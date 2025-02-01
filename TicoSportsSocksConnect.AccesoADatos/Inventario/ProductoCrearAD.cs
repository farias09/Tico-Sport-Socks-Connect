using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicoSportSocksConnect.Abstracciones.AD.Interfaces.Inventario;
using TicoSportSocksConnect.Abstracciones.Modelos.Inventario;
using TicoSportSocksConnect.Abstracciones.ModelosBaseDeDatos;

namespace TicoSportsSocksConnect.AccesoADatos.Inventario
{
    public class ProductoCrearAD : IProductoCrearAD
    {
        private readonly Contexto _contexto;

        public ProductoCrearAD(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task CrearAsync(ProductosDto producto)
        {
            var nuevoProducto = new ProductosTabla
            {
                nombre = producto.nombre,
                descripcion = producto.descripcion,
                precio = producto.precio,
                stock = producto.stock,
                imagen = producto.imagen,
                Categoria_ID = producto.Categoria_ID
            };
            await _contexto.Productos.AddAsync(nuevoProducto);
            await _contexto.SaveChangesAsync();
        }
    }
}
