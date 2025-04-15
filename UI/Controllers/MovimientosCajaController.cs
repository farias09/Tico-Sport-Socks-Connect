    using Abstracciones.LN.Interfaces.MovimientosCaja;
    using Abstracciones.Modelos.MovimientosCaja;
    using Microsoft.AspNet.Identity;
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
            private readonly IListarMovimientosLN _listarMovimientosLN;

            public MovimientosCajaController(ICrearMovimientoLN crearMovimientoLN, IListarMovimientosLN listarMovimientosLN)
            {
                _crearMovimientoLN = crearMovimientoLN;
                _listarMovimientosLN = listarMovimientosLN;
            }
            // GET: MovimientosCaja
            public ActionResult Listar()
            {
                var movimientos = _listarMovimientosLN.Listar();
                return View(movimientos);
            }

            [HttpGet]
            public ActionResult ObtenerMovimientosPorCaja(int cajaId)
            {
                try
                {
                    var movimientos = _listarMovimientosLN.ListarPorCaja(cajaId);
                    return Json(movimientos, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    Response.StatusCode = 500;
                    return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
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
                modelo.Fecha = DateTime.Now;
                modelo.Usuario_ID = User.Identity.GetUserId();

                if (!ModelState.IsValid)
                {
                    return Json(new { success = false, message = "Datos inválidos." });
                }

                try
                {
                    if (modelo.Monto == 0)
                    {
                        return Json(new { success = false, message = "El monto debe ser diferente de 0." });
                    }

                    if (string.IsNullOrWhiteSpace(modelo.Tipo_Movimiento) ||
                        (modelo.Tipo_Movimiento != "Ingreso" && modelo.Tipo_Movimiento != "Egreso"))
                    {
                        return Json(new { success = false, message = "Tipo de movimiento inválido." });
                    }

                    int idMovimiento = await _crearMovimientoLN.Guardar(modelo);

                    if (idMovimiento > 0)
                    {
                        return Json(new { success = true, message = "Movimiento registrado correctamente." });
                    }
                    else
                    {
                        return Json(new { success = false, message = "Error al guardar el movimiento." });
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = "Error: " + ex.Message });
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
