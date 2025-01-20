using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    public class ClientesController : Controller
    {
        // Método para mostrar la lista de clientes
        public IActionResult Index()
        {

            var clientes = new List<ClienteViewModel>
            {
                new ClienteViewModel { Id = 1, Nombre = "Carlos Ramírez", Email = "carlos@gmail.com", Telefono = "8888-1234", Direccion = "San José" },
                new ClienteViewModel { Id = 2, Nombre = "Sofía López", Email = "sofia@gmail.com", Telefono = "8888-5678", Direccion = "Alajuela" },
                new ClienteViewModel { Id = 3, Nombre = "Luis González", Email = "luis@gmail.com", Telefono = "8888-9101", Direccion = "Cartago" }
            };


            return View(clientes);
        }
    }

  
    public class ClienteViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
    }
}
