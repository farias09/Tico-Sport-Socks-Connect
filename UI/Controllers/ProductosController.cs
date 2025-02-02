using Abstracciones.LN.Interfaces.Productos.CrearProducto;
using Abstracciones.LN.Interfaces.Productos.ListarProducto;
using Abstracciones.Modelos.Productos;
using LN.Productos.CrearProducto;
using LN.Productos.ListarProductos;
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

        public ProductosController() 
        {
            _crearProducto = new CrearProductoLN();
            _listarProducto = new ListarProductoLN();
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

                int cantidadDeDatosGuardados = await _crearProducto.Crear(modeloDelProducto);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Productos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
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
    }
}
