using Abstracciones.ModelosBaseDeDatos;
using AccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Twilio.Types;
using Twilio;
using UI.Models;
using Twilio.Rest.Api.V2010.Account;


namespace UI.Controllers
{
    public class ConversacionesController : Controller
    {
        private readonly Contexto _contexto;

        public ConversacionesController()
        {
            _contexto = new Contexto();
        }

        public ActionResult Index(int? id)
        {
            // Obtener lista de conversaciones
            var conversaciones = _contexto.MensajesTabla
                .Where(m => m.emisor_ID != 5)
                .Select(m => new { m.emisor_ID, m.receptor_ID })
                .Distinct()
                .ToList();

            var listaConversaciones = conversaciones
                .Select(c => new ConversacionViewModel
                {
                    UsuarioId = c.emisor_ID,
                    Nombre = _contexto.UsuariosTabla
                        .Where(u => u.Usuario_ID == c.emisor_ID)
                        .Select(u => u.Nombre)
                        .FirstOrDefault() ?? "Usuario Desconocido",
                    Numero = _contexto.UsuariosTabla
                        .Where(u => u.Usuario_ID == c.emisor_ID)
                        .Select(u => u.Numero)
                        .FirstOrDefault() ?? "Desconocido"
                })
                .ToList();

            var productos = _contexto.ProductosTabla
                .Select(p => new Abstracciones.Modelos.Productos.ProductosDto
                {
                    Producto_ID = p.Producto_ID,
                    nombre = p.nombre,
                    imagen = p.imagen,
                    precio = p.precio,
                    stock = p.stock
                })
                .ToList();

            // Crear el modelo combinado
            var modelo = new ConversacionesChatViewModel
            {
                Conversaciones = listaConversaciones,
                Chat = null,
                Productos = productos 
            };

            // Si hay un ID de usuario seleccionado, cargar los mensajes
            if (id.HasValue)
            {
                var usuario = _contexto.UsuariosTabla.FirstOrDefault(u => u.Usuario_ID == id.Value);
                var mensajes = _contexto.MensajesTabla
                    .Where(m => m.emisor_ID == id.Value || m.receptor_ID == id.Value)
                    .OrderBy(m => m.fecha)
                    .ToList();

                modelo.Chat = new ChatViewModel
                {
                    UsuarioId = usuario?.Usuario_ID ?? 0,
                    Nombre = usuario?.Nombre ?? "Usuario Desconocido",
                    Numero = usuario?.Numero ?? "Desconocido",
                    Mensajes = mensajes.Select(m => new MensajeViewModel
                    {
                        Contenido = m.contenido,
                        Fecha = m.fecha,
                        EsMio = m.emisor_ID != id.Value
                    }).ToList()
                };
            }

            return View(modelo);
        }

        public ActionResult Chat(int id)
        {
            var usuario = _contexto.UsuariosTabla.FirstOrDefault(u => u.Usuario_ID == id);

            if (usuario == null)
            {
                return HttpNotFound();
            }

            var mensajes = _contexto.MensajesTabla
                .Where(m => m.emisor_ID == id || m.receptor_ID == id)
                .OrderBy(m => m.fecha)
                .ToList();

            var chatViewModel = new ChatViewModel
            {
                UsuarioId = usuario.Usuario_ID,
                Nombre = usuario.Nombre ?? "Usuario Desconocido",
                Numero = usuario.Numero ?? "Desconocido",
                Mensajes = mensajes.Select(m => new MensajeViewModel
                {
                    Contenido = m.contenido,
                    Fecha = m.fecha,
                    EsMio = m.emisor_ID != id 
                }).ToList()
            };

            return View(chatViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> EnviarMensaje(int id, string contenido)
        {
            Console.WriteLine($"Enviando mensaje a ID: {id}, Contenido: {contenido}");

            if (string.IsNullOrEmpty(contenido))
            {
                return Json(new { success = false, message = "El mensaje no puede estar vacío." });
            }

            var usuario = _contexto.UsuariosTabla.FirstOrDefault(u => u.Usuario_ID == id);

            if (usuario == null || string.IsNullOrEmpty(usuario.Numero))
            {
                return Json(new { success = false, message = "Usuario no encontrado o sin número." });
            }

            var nuevoMensaje = new MensajesTabla
            {
                emisor_ID = 5, // ← el admin
                receptor_ID = usuario.Usuario_ID,
                contenido = contenido,
                fecha = DateTime.UtcNow
            };

            _contexto.MensajesTabla.Add(nuevoMensaje);
            _contexto.SaveChanges();

            try
            {
                await EnviarMensajeWhatsApp(usuario.Numero, contenido);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al enviar mensaje por WhatsApp: {ex.Message}");
                return Json(new { success = false, message = "Mensaje guardado, pero no se pudo enviar por WhatsApp." });
            }

            return Json(new { success = true });
        }


        private async Task EnviarMensajeWhatsApp(string numeroDestino, string contenido)
        {
            string accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
            string authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");

            TwilioClient.Init(accountSid, authToken);

            // Asegurarse de que el número venga con el formato correcto
            if (!numeroDestino.StartsWith("+"))
                numeroDestino = "+506" + numeroDestino;

            var mensaje = await MessageResource.CreateAsync(
                from: new PhoneNumber("whatsapp:+14155238886"), // Número de Twilio sandbox
                to: new PhoneNumber($"whatsapp:{numeroDestino}"),
                body: contenido
            );

            Console.WriteLine($"✅ Mensaje enviado a {numeroDestino}: {mensaje.Sid}");
        }

        [HttpGet]
        public ActionResult ObtenerMensajes(int id)
        {
            var mensajes = _contexto.MensajesTabla
                .Where(m => m.emisor_ID == id || m.receptor_ID == id)
                .OrderBy(m => m.fecha)
                .Select(m => new MensajeViewModel
                {
                    Contenido = m.contenido,
                    Fecha = m.fecha,
                    EsMio = (m.emisor_ID == 5)
                })
                .ToList();

            return PartialView("_Mensajes", mensajes);
        }


    }
}