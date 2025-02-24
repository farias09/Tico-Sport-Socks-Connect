using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TicoSportSocksConnect.Abstracciones.LN.Interfaces.Inventario;
using TicoSportSocksConnect.Abstracciones.Modelos.Inventario;

namespace Frontend.Controllers
{
    public class InventarioController : Controller
    {
        private readonly IProductoCrearLN _productoCrearLN;
        private readonly IProductoLeerLN _productoLeerLN;
        private readonly IProductoActualizarLN _productoActualizarLN;
        private readonly IProductoEliminarLN _productoEliminarLN;

        public InventarioController(
            IProductoCrearLN productoCrearLN,
            IProductoLeerLN productoLeerLN,
            IProductoActualizarLN productoActualizarLN,
            IProductoEliminarLN productoEliminarLN)
        {
            _productoCrearLN = productoCrearLN;
            _productoLeerLN = productoLeerLN;
            _productoActualizarLN = productoActualizarLN;
            _productoEliminarLN = productoEliminarLN;
        }

        public async Task<ActionResult> Index()
        {
            var productos = await _productoLeerLN.ObtenerTodosAsync();
            return View(productos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegistrarProducto(ProductosDto producto)
        {
            try
            {
                await _productoCrearLN.CrearAsync(producto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}