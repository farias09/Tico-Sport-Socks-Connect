using Abstracciones.LN.Interfaces.Cajas.ListarCaja;
using Abstracciones.LN.Interfaces.Usuarios.ListarUsuario;
using Abstracciones.LN.Interfaces.Ventas.CrearVenta;
using Abstracciones.LN.Interfaces.Ventas.ListarVenta;
using Abstracciones.Modelos.Caja;
using Abstracciones.Modelos.Usuarios;
using Abstracciones.Modelos.Ventas;
using LN.Usuarios.ListarUsuario;
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
        private readonly IListarUsuarioLN _listarUsuario;
        private readonly IListarCajaLN _listarCaja;

        public VentasController(ICrearVentaLN crearVenta, IListarVentaLN listarVenta, IListarUsuarioLN listarUsuario, IListarCajaLN listarCaja)
        {
            _crearVenta = crearVenta;
            _listarVenta = listarVenta;
            _listarUsuario = listarUsuario ?? throw new ArgumentNullException(nameof(listarUsuario));
            _listarCaja = listarCaja;

            if (listarUsuario == null)
            {
                throw new Exception("🚨 Unity NO está inyectando IListarUsuarioLN en VentasController.");
            }
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
            CargarListas();
            return View();
        }

        // POST: Ventas/Create
        [HttpPost]
        public ActionResult CrearVenta(VentasDto modeloVenta)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                CargarListas();
                return View(modeloVenta);
                }
                Task ventaCreada = _crearVenta.Crear(modeloVenta);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
            TempData["Error"] = "Error al registrar la venta: " + ex.Message;
            CargarListas();
            return View(modeloVenta);
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

        private void CargarListas()
        {
            var listaUsuarios = _listarUsuario.Listar();
            var listaCajas = _listarCaja.Listar();

            if (listaUsuarios == null || !listaUsuarios.Any())
                listaUsuarios = new List<UsuarioDto> { new UsuarioDto { Usuario_ID = 0, Nombre = "No hay usuarios disponibles" } };
            if (listaCajas == null || !listaCajas.Any())
                listaCajas = new List<CajasDto> { new CajasDto { Caja_ID = 0, nombre_caja = "No hay cajas disponibles" } };

            ViewBag.Usuarios = new SelectList(listaUsuarios, "Usuario_ID", "Nombre");
            ViewBag.Cajas = new SelectList(listaCajas, "Caja_ID", "nombre_caja");
        }

    }
}
