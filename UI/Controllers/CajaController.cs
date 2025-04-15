using Abstracciones.LN.Interfaces.Cajas.CerrarCaja;
using Abstracciones.LN.Interfaces.Cajas.CrearCaja;
using Abstracciones.LN.Interfaces.Cajas.ListarCaja;
using Abstracciones.LN.Interfaces.MovimientosCaja;
using Abstracciones.Modelos.Caja;
using Abstracciones.Modelos.MovimientosCaja;
using AccesoADatos;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class CajaController : Controller
    {
        private readonly ICrearCajaLN _crearCajaLN;
        private readonly ICrearMovimientoLN _crearMovimientoLN;
        private readonly IListarCajaLN _listarCajaLN;
        private readonly ICerrarCajaLN _cerrarCajaLN;

        public CajaController(ICrearMovimientoLN crearMovimientoLN, ICrearCajaLN crearCajaLN, IListarCajaLN listarCajaLN, ICerrarCajaLN cerrarCajaLN)
        {
            _crearCajaLN = crearCajaLN;
            _crearMovimientoLN = crearMovimientoLN;
            _listarCajaLN = listarCajaLN;
            _cerrarCajaLN = cerrarCajaLN;
        }

        // GET: Caja
        public ActionResult Index()
        {
            var identidad = (System.Security.Claims.ClaimsIdentity)User.Identity;

            foreach (var claim in identidad.Claims)
            {
                System.Diagnostics.Debug.WriteLine($"Claim Type: {claim.Type}, Claim Value: {claim.Value}");
            }

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
            try
            {
                modelo.Usuario_ID = ObtenerUsuarioGuidDesdeIdentity();
                ModelState.Remove("Usuario_ID");
                modelo.estado = true;
                modelo.fecha_apertura = DateTime.Now;

                
                if (!ModelState.IsValid)
                {
                    TempData["Error"] = "Los datos ingresados no son válidos.";
                    return RedirectToAction("Index");
                }

                // ⚠️ Validamos si ya hay una caja abierta
                if (_crearCajaLN.VerificarCajaAbierta())
                {
                    TempData["Error"] = "Ya existe una caja abierta.";
                    return RedirectToAction("Index");
                }

                // 🧩 Guardamos la caja
                int idCaja = _crearCajaLN.Crear(modelo);

                if (idCaja > 0)
                {
                    TempData["Success"] = "Caja registrada correctamente.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Error"] = "No se pudo registrar la caja.";
                    TempData["ShowAbrirCajaModal"] = true;
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("🔥 Error completo: " + ex.ToString());
                TempData["Error"] = "Ocurrió un error al procesar la solicitud: " + ex.Message;
                return RedirectToAction("Index");
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

        [HttpPost]
        public ActionResult CerrarCaja(int cajaId, decimal montoFinal)
        {
            try
            {
                if (montoFinal <= 0)
                {
                    TempData["Error"] = "El monto final debe ser mayor a 0.";
                    return RedirectToAction("Index");
                }

                bool exito = _cerrarCajaLN.CerrarCaja(cajaId, montoFinal);

                if (exito)
                {
                    TempData["Success"] = "Caja cerrada correctamente.";
                }
                else
                {
                    TempData["Error"] = "No se pudo cerrar la caja. Verifica que esté abierta.";
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al cerrar la caja: " + ex.Message;
                return RedirectToAction("Index");
            }
        }

        private string ObtenerUsuarioGuidDesdeIdentity()
        {
            return User.Identity.GetUserId();
        }

    }
}
