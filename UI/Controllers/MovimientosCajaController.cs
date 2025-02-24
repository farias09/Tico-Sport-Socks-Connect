using Abstracciones.LN.Interfaces.MovimientosCaja;
using Abstracciones.Modelos.MovimientosCaja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class MovimientosCajaController : Controller
    {
        private readonly ICrearMovimientoLN _crearMovimientoLN;

        public MovimientosCajaController(ICrearMovimientoLN crearMovimientoLN)
        {
            _crearMovimientoLN = crearMovimientoLN; 
        }
        // GET: MovimientosCaja
        public ActionResult Index()
        {
            return View();
        }

        // GET: MovimientosCaja/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MovimientosCaja/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MovimientosCaja/Create
        [HttpPost]
        public async Task<ActionResult> CreateMovimiento(MovimientosCajaDto modelo)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Los datos ingresados no son válidos.";
                return View(modelo);
            }

            try
            {
                // Verificar que el monto sea válido
                if (modelo.Monto <= 0)
                {
                    TempData["Error"] = "El monto debe ser mayor a 0.";
                    return View(modelo);
                }

                // Determinar el tipo de movimiento
                if (string.IsNullOrWhiteSpace(modelo.Tipo_Movimiento) ||
                    (modelo.Tipo_Movimiento != "Ingreso" && modelo.Tipo_Movimiento != "Egreso"))
                {
                    TempData["Error"] = "El tipo de movimiento debe ser 'Ingreso' o 'Egreso'.";
                    return View(modelo);
                }

                // Guardar el movimiento en la base de datos
                int idMovimiento = await _crearMovimientoLN.Guardar(modelo);

                if (idMovimiento > 0)
                {
                    TempData["Success"] = "Movimiento registrado correctamente.";
                    return RedirectToAction("Index"); // Redirige a la lista de movimientos
                }
                else
                {
                    TempData["Error"] = "No se pudo registrar el movimiento.";
                    return View(modelo);
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Ocurrió un error al procesar la solicitud: " + ex.Message;
                return View(modelo);
            }
        }

        // GET: MovimientosCaja/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MovimientosCaja/Edit/5
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

        // GET: MovimientosCaja/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MovimientosCaja/Delete/5
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
