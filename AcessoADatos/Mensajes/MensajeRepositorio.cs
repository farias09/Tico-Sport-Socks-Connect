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
            string numeroReceptor = "+14155238886"; // Ejemplo: el número del sandbox de Twilio

            // Verificar si el Emisor existe en la base de datos usando su número
            var usuarioEmisor = await _contexto.UsuariosTabla.FirstOrDefaultAsync(u => u.Numero == numeroRemitente);

            if (usuarioEmisor == null)
            {
                usuarioEmisor = new UsuariosTabla
                {
                    Nombre = "Usuario Desconocido",
                    Numero = numeroRemitente,
                    Email = $"{numeroRemitente}@autogenerado.com",
                    FechaRegistro = DateTime.UtcNow,
                    Rol_ID = 2
                };

                _contexto.UsuariosTabla.Add(usuarioEmisor);
                await _contexto.SaveChangesAsync();
                Console.WriteLine($"✅ Usuario Emisor {numeroRemitente} creado automáticamente.");
            }

            // 🔹 3️⃣ Verificar si el Receptor existe en la base de datos usando su número
            var usuarioReceptor = await _contexto.UsuariosTabla.FirstOrDefaultAsync(u => u.Numero == numeroReceptor);

            if (usuarioReceptor == null)
            {
                usuarioReceptor = new UsuariosTabla
                {
                    Nombre = "Usuario Administrador",
                    Numero = numeroReceptor,
                    Email = $"{numeroReceptor}@autogenerado.com",
                    FechaRegistro = DateTime.UtcNow,
                    Rol_ID = 1
                };

                _contexto.UsuariosTabla.Add(usuarioReceptor);
                await _contexto.SaveChangesAsync();
                Console.WriteLine($"✅ Usuario Receptor {numeroReceptor} creado automáticamente.");
            }

            // 🔹 4️⃣ Insertar el mensaje asegurando que Emisor y Receptor sean correctos
            var nuevoMensaje = new MensajesTabla
            {
                emisor_ID = usuarioEmisor.Usuario_ID,
                receptor_ID = usuarioReceptor.Usuario_ID, // Asegurar que el receptor tenga un ID válido
                contenido = contenido,
                fecha = fecha
            };

            _contexto.MensajesTabla.Add(nuevoMensaje);
            await _contexto.SaveChangesAsync();

            Console.WriteLine("✅ Mensaje guardado correctamente.");
        }

    }
}
