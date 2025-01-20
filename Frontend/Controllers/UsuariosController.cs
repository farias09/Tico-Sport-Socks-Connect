using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    public class UsuariosController : Controller
    {
        public IActionResult Index()
        {
            var usuarios = new List<UsuarioViewModel>
            {
                new UsuarioViewModel { Id = 1, Nombre = "David Arias", Email = "david.arias@ticosportsocks.com", Rol = "Administrador" },
                new UsuarioViewModel { Id = 2, Nombre = "Nichelle Arias", Email = "nichelle.arias@ticosportsocks.com", Rol = "Usuario" },
                new UsuarioViewModel { Id = 3, Nombre = "Fabián Arias", Email = "fabian.arias@ticosportsocks.com", Rol = "Usuario" },
                new UsuarioViewModel { Id = 4, Nombre = "Jose Ignacio Arias", Email = "ignacio.arias@ticosportsocks.com", Rol = "Usuario" },
                new UsuarioViewModel { Id = 5, Nombre = "Fabiola Chaves", Email = "fabiola.chaves@ticosportsocks.com", Rol = "Usuario" }
            };

            return View(usuarios);
        }
    }
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }
    }
}
