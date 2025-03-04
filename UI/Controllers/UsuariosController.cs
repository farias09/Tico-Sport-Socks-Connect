using System.Web.Mvc;
using Abstracciones.LN.Interfaces.Usuarios.ListarUsuario;
using UI.Models;
using System.Collections.Generic;
using System.Linq;

namespace UI.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IListarUsuarioLN _listarUsuarioLN;

        public UsuariosController(IListarUsuarioLN listarUsuarioLN)
        {
            _listarUsuarioLN = listarUsuarioLN;
        }

        public ActionResult Index()
        {
            var usuariosDto = _listarUsuarioLN.Listar();

            var usuariosViewModel = usuariosDto.Select(u => new UsuarioViewModel
            {
                Id = u.Usuario_ID,
                Nombre = u.Nombre,
                Email = u.Email,
                Rol = u.Rol_ID == 1 ? "Administrador" : "Usuario"
            }).ToList();

            return View(usuariosViewModel);
        }
    }
}