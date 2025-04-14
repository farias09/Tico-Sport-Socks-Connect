using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LN.Usuarios.ListarUsuario;
using AccesoADatos;
using LN.Ordenes.OrdenService;
using LN.Cajas.ListarCaja;
using LN.General.Conversiones.Cajas;
using LN.General.Conversiones.Cajas.ConvertirACajasDto;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using TicoSportSocksConnect.UI;
using LN.Productos.ListarProductos;
using System.Threading.Tasks;
using Abstracciones.Modelos.Productos;
using Abstracciones.Modelos.Usuarios;
using Abstracciones.Modelos.Ordenes;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly OrdenService _ordenService;
        private readonly ListarUsuarioLN _listarUsuarioLN;
        private readonly ListarCajaLN _listarCajaLN;
        private readonly ListarProductoLN _listarProductoLN;

        public HomeController()
        {
            _ordenService = new OrdenService(new AcessoADatos.Ordenes.OrdenRepositorio());
            _listarUsuarioLN = new ListarUsuarioLN(new AcessoADatos.Usuarios.ListarUsuario.ListarUsuarioAD(new Contexto()), null);
            _listarCajaLN = new ListarCajaLN(new AcessoADatos.Cajas.ListarCaja.ListarCajaAD(new Contexto()), new ConvertirACajasDto());
            _listarProductoLN = new ListarProductoLN();
        }

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var user = userManager.FindById(User.Identity.GetUserId());
                ViewBag.NombreCompleto = $"{user.Nombre} {user.Apellido}";
            }

            Func<int, string> obtenerNombreUsuario = id =>
                _listarUsuarioLN.ObtenerUsuarioPorId(id)?.Nombre ?? "Desconocido";

            Func<int?, string> obtenerNombreCaja = id =>
            {
                if (id == null) return "N/A";
                var caja = _listarCajaLN.ObtenerCajaPorId(id.Value);
                return caja?.nombre_caja ?? "Desconocida";
            };

            var resumen = _ordenService.ObtenerUltimasOrdenesConDetalles(obtenerNombreUsuario, obtenerNombreCaja);

            return View(resumen);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}