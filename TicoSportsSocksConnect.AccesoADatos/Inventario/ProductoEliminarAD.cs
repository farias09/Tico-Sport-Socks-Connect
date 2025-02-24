using System;
using System.Threading.Tasks;
using TicoSportSocksConnect.Abstracciones.AD.Interfaces.Inventario;
using TicoSportSocksConnect.Abstracciones.Modelos.Inventario;
using TicoSportSocksConnect.Abstracciones.ModelosBaseDeDatos;

namespace TicoSportsSocksConnect.AccesoADatos.Inventario
{
    public class ProductoEliminarAD : IProductoEliminarAD
    {
        private readonly Contexto _contexto;

        public ProductoEliminarAD(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task EliminarAsync(int id)
        {
            // Buscar el producto por su ID
            var producto = await _contexto.Productos.FindAsync(id);

            if (producto == null)
            {
                throw new KeyNotFoundException($"No se encontró el producto con ID {id}");
            }

            // Eliminar el producto de la base de datos
            _contexto.Productos.Remove(producto);
            await _contexto.SaveChangesAsync();
        }
    }
}