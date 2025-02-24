using Abstracciones.ModelosBaseDeDatos;
using AccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Models;

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

            // Asumiendo que tienes una tabla o método para obtener productos,
            // mapea los datos a tu ProductosDto.
            var productos = _contexto.ProductosTabla
                .Select(p => new Abstracciones.Modelos.Productos.ProductosDto
                {
                    // Ajusta los nombres de las propiedades según tu modelo
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
        public ActionResult EnviarMensaje(int id, string contenido)
        {
            if (string.IsNullOrEmpty(contenido))
            {
                return Json(new { success = false, message = "El mensaje no puede estar vacío." });
            }

            var usuario = _contexto.UsuariosTabla.FirstOrDefault(u => u.Usuario_ID == id);

            if (usuario == null)
            {
                return Json(new { success = false, message = "Usuario no encontrado." });
            }

            var nuevoMensaje = new MensajesTabla
            {
                emisor_ID = 1, 
                receptor_ID = usuario.Usuario_ID,
                contenido = contenido,
                fecha = DateTime.UtcNow
            };

            _contexto.MensajesTabla.Add(nuevoMensaje);
            _contexto.SaveChanges();

            return Json(new { success = true });
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
                    EsMio = (m.emisor_ID == id)
                })
                .ToList();

            return PartialView("_Mensajes", mensajes);
        }


    }
}