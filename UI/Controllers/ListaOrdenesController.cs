using System;
using System.Linq;
using System.Web.Mvc;
using Abstracciones.Modelos.Ordenes;
using AccesoADatos;
using LN.Ordenes.OrdenService;
using LN.Usuarios.ListarUsuario;

namespace UI.Controllers
{
    public class ListaOrdenesController : Controller
    {
        private readonly OrdenService _ordenService;
        private readonly ListarUsuarioLN _listarUsuarioLN;

        public ListaOrdenesController()
        {
            _ordenService = new OrdenService(new AcessoADatos.Ordenes.OrdenRepositorio());
            _listarUsuarioLN = new ListarUsuarioLN(new AcessoADatos.Usuarios.ListarUsuario.ListarUsuarioAD(new Contexto()), null);
        }

        public ActionResult Index()
        {
            // Obtener todas las órdenes
            var ordenes = _ordenService.ObtenerOrdenes();

            // Obtener los usuarios para mostrar sus nombres
            var usuarios = _listarUsuarioLN.Listar();

            // Crear una lista de modelos de vista con la información combinada
            var modelo = ordenes.Select(o => new OrdenResumenDto
            {
                Orden_ID = o.Orden_ID,
                UsuarioNombre = usuarios.FirstOrDefault(u => u.Usuario_ID == o.Usuario_ID)?.Nombre ?? "Cliente no encontrado",
                FechaOrden = o.FechaOrden,
                Total = o.Total,
                Estado = o.Estado,
                TipoVenta = o.TipoVenta ?? "No especificado"
            }).ToList();

            return View(modelo);
        }

        // GET: ListaOrdenesController/Details/5
        [HttpGet]
        public JsonResult ObtenerDetallesOrden(int id)
        {
            var orden = _ordenService.ObtenerOrdenPorId(id);
            if (orden == null) return Json(new { success = false }, JsonRequestBehavior.AllowGet);

            var detalles = _ordenService.ObtenerDetallesPorOrden(id);
            var usuario = _listarUsuarioLN.ObtenerUsuarioPorId(orden.Usuario_ID);

            return Json(new
            {
                success = true,
                orden = new
                {
                    orden.Orden_ID,
                    orden.FechaOrden,
                    orden.Total,
                    orden.Estado,
                    orden.TipoVenta
                },
                cliente = new
                {
                    Nombre = usuario?.Nombre ?? "Cliente no encontrado",
                    Email = usuario?.Email ?? "N/A"
                },
                productos = detalles.Select(d => new {
                    d.NombreProducto,
                    d.Cantidad,
                    d.PrecioUnitario,
                    d.Subtotal
                })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AnularOrden(int id)
        {
            try
            {
                var contexto = new Contexto();
                var orden = contexto.OrdenesTabla.FirstOrDefault(o => o.Orden_ID == id);

                if (orden == null)
                {
                    return Json(new { success = false, message = "Orden no encontrada" });
                }

                // Actualizar el estado a "Cancelada"
                orden.Estado = "Cancelada";
                contexto.SaveChanges();

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // GET: ListaOrdenesController/Create
        public ActionResult Create()
        {
            return View();
        }
    }
}
