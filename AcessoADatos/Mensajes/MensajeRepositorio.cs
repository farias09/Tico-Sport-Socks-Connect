using Abstracciones.AD.Interfaces.Mensajes;
using Abstracciones.ModelosBaseDeDatos;
using AccesoADatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AcessoADatos.Mensajes
{
    public class MensajeRepositorio : IMensajeRepositorio
    {
        private readonly Contexto _contexto;

        public MensajeRepositorio(Contexto contexto)
        {
            _contexto = contexto;
        }
        public async Task GuardarMensajeAsync(string numeroRemitente, string contenido, DateTime fecha)
        {
            numeroRemitente = numeroRemitente.Replace("whatsapp:", "").Trim();

            // Verificar si el Emisor (cliente) existe
            var usuarioEmisor = await _contexto.UsuariosTabla
                .FirstOrDefaultAsync(u => u.Numero == numeroRemitente);

            if (usuarioEmisor == null)
            {
                usuarioEmisor = new UsuariosTabla
                {
                    Nombre = "Usuario Desconocido",
                    Numero = numeroRemitente,
                    Email = $"{numeroRemitente}@autogenerado.com",
                    FechaRegistro = DateTime.UtcNow,
                    Rol_ID = 2,
                    estado = true
                };

                _contexto.UsuariosTabla.Add(usuarioEmisor);
                await _contexto.SaveChangesAsync();

                Console.WriteLine($"✅ Usuario Emisor {numeroRemitente} creado automáticamente.");
            }

            // Insertar el mensaje
            var nuevoMensaje = new MensajesTabla
            {
                emisor_ID = usuarioEmisor.Usuario_ID,
                receptor_ID = 5, // Admin virtual
                contenido = contenido,
                fecha = fecha
            };

            _contexto.MensajesTabla.Add(nuevoMensaje);
            await _contexto.SaveChangesAsync();

            Console.WriteLine("✅ Mensaje guardado correctamente.");
        }
    }
}
