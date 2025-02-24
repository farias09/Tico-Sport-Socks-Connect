using Abstracciones.LN.Interfaces.Cajas.CrearCaja;
using Abstracciones.LN.Interfaces.Cajas.ListarCaja;
using Abstracciones.LN.Interfaces.MovimientosCaja;
using Abstracciones.Modelos.Caja;
using Abstracciones.Modelos.MovimientosCaja;
using LN.Cajas.CrearCaja;
using LN.Cajas.ListarCaja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class CajaController : Controller
    {
        private readonly ICrearCajaLN _crearCajaLN;
        private readonly ICrearMovimientoLN _crearMovimientoLN;
        private readonly IListarCajaLN _listarCajaLN;

        public CajaController(ICrearMovimientoLN crearMovimientoLN, ICrearCajaLN crearCajaLN, IListarCajaLN listarCajaLN)
        {
            _crearCajaLN = crearCajaLN;
            _crearMovimientoLN = crearMovimientoLN;
            _listarCajaLN = listarCajaLN;
        }

        // GET: Caja
        public ActionResult Index()
        {
            List<CajasDto> laListaDeCajas = _listarCajaLN.Listar();
            return View(laListaDeCajas);
        }

        // GET: Caja/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Caja/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Caja/Create
        [HttpPost]
        public ActionResult Create(CajasDto modelo)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Los datos ingresados no son válidos.";
                return View(modelo);
            }

            try
            {
                // -------------------------------------------------------------------
                // Validar que la caja no esté duplicada (Opcional, si se necesita)
                var cajaExistente = _crearCajaLN.VerificarCajaAbierta();
                if (cajaExistente)
                {
                    TempData["Error"] = "Ya existe una caja abierta.";
                    return RedirectToAction("Index");
                }
                // -------------------------------------------------------------------

                // Establecer estado inicial
                modelo.estado = true;
                modelo.fecha_apertura = DateTime.Now;

                // -------------------------------------------------------------------
                // Guardar la caja en la base de datos
                int idCaja = _crearCajaLN.Crear(modelo);
                // -------------------------------------------------------------------

                if (idCaja > 0)
                {
                    TempData["Success"] = "Caja registrada correctamente.";
                    return RedirectToAction("Details", new { id = idCaja });
                }
                else
                {
                    TempData["Error"] = "No se pudo registrar la caja.";
                    return View(modelo);
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Ocurrió un error al procesar la solicitud: " + ex.Message;
                return View(modelo);
            }
        }

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

        // GET: Caja/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Caja/Edit/5
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

        // GET: Caja/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Caja/Delete/5
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
