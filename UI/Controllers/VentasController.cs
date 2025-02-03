using Abstracciones.LN.Interfaces.Ventas.CrearVenta;
using Abstracciones.LN.Interfaces.Ventas.ListarVenta;
using Abstracciones.Modelos.Ventas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class VentasController : Controller
    {
        private readonly ICrearVentaLN _crearVenta;
        private readonly IListarVentaLN _listarVenta;

        public VentasController(ICrearVentaLN crearVenta, IListarVentaLN listarVenta)
        {
            _crearVenta = crearVenta;
            _listarVenta = listarVenta;
        }

        public VentasController() { }

        // GET: Ventas
        public ActionResult Index()
        {
            List<VentasDto> listaVentas = _listarVenta.Listar();
            return View(listaVentas);
        }

        // GET: Ventas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ventas/Create
        public ActionResult CrearVenta()
        {
            return View();
        }

        // POST: Ventas/Create
        [HttpPost]
        public async Task<ActionResult> CrearVenta(VentasDto modeloVenta)
        {
            try
            {
                int cantidadDeDatosGuardados = await _crearVenta.Crear(modeloVenta);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al registrar la venta: " + ex.Message;
                return View();
            }
        }

        // GET: Ventas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ventas/Edit/5
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

        // GET: Ventas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ventas/Delete/5
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
