using Abstracciones.LN.Interfaces.Productos.ActualizarProducto;
using Abstracciones.LN.Interfaces.Productos.CambiarEstado;
using Abstracciones.LN.Interfaces.Productos.CrearProducto;
using Abstracciones.LN.Interfaces.Productos.ListarProducto;
using Abstracciones.LN.Interfaces.Productos.ObtenerPorId;
using Abstracciones.Modelos.Productos;
using LN.Productos.ActualizarProducto;
using LN.Productos.CambiarEstado;
using LN.Productos.CrearProducto;
using LN.Productos.ListarProductos;
using LN.Productos.ObtenerPorId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class ProductosController : Controller
    {
        ICrearProductoLN _crearProducto;
        IListarProductoLN _listarProducto;
        IActualizarProductoLN _actualizarProducto;
        IObtenerProductoPorIdLN _obtenerPorId;
        ICambiarEstadoProductoLN _cambiarEstado;

        public ProductosController()
        {
            _crearProducto = new CrearProductoLN();
            _listarProducto = new ListarProductoLN();
            _actualizarProducto = new ActualizarProductoLN();
            _obtenerPorId = new ObtenerProductoPorIdLN();
            _cambiarEstado = new CambiarEstadoProductoLN();
        }
        // GET: Productos
        public ActionResult Index()
        {
            List<ProductosDto> laListaDeProductos = _listarProducto.Listar();
            return View(laListaDeProductos);
        }

        // GET: Productos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Productos/Create
        public ActionResult CrearProducto()
        {
            return View();
        }

        // POST: Productos/Create
        [HttpPost]
        public async Task<ActionResult> CrearProducto(ProductosDto modeloDelProducto)
        {
            try
            {
                var productoExiste = _listarProducto.Listar()
                    .FirstOrDefault(elCodigo => elCodigo.CodigoDelProducto == modeloDelProducto.CodigoDelProducto);

                if (productoExiste != null)
                {
                    ViewBag.MensajeDeError = "El codigo del producto ingresado ya está registrado.";
                    return View(modeloDelProducto);
                }

                int cantidadDeDatosGuardados = await _crearProducto.Guardar(modeloDelProducto);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Productos/Edit/5
        public ActionResult ActualizarProducto(int id)
        {
            ProductosDto elProducto = _obtenerPorId.Obtener(id);
            return View(elProducto);
        }

        // POST: Productos/Edit/5
        [HttpPost]
        public async Task<ActionResult> ActualizarProducto(ProductosDto elProducto)
        {
            try
            {
                var existeProducto = _listarProducto.Listar();
                bool codigoDuplicado = existeProducto
                    .Any(elProductoValido => elProductoValido.CodigoDelProducto == elProducto.CodigoDelProducto && elProductoValido.Producto_ID != elProducto.Producto_ID);
                if (codigoDuplicado)
                {
                    ModelState.AddModelError("CodigoDelProducto", "Ya existe ese codigo de producto.");
                    return View(elProducto);
                }
                else
                {
                    int cantidadDeDatosActualizados = await _actualizarProducto.Editar(elProducto);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Productos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public async Task<ActionResult> Activar(int id)
        {
            try
            {
                bool resultado = await _cambiarEstado.CambiarEstado(id, true);

                if (resultado)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Mensaje = "No se pudo activar el producto.";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Ocurrió un error inesperado.";
                return RedirectToAction("Index");
            }
        }

        public async Task<ActionResult> Inactivar(int id)
        {
            try
            {
                bool resultado = await _cambiarEstado.CambiarEstado(id, false);

                if (resultado)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Mensaje = "No se pudo inactivar el producto.";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Ocurrió un error inesperado.";
                return RedirectToAction("Index");
            }
        }
    }
}