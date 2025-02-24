using Abstracciones.AD.Interfaces.Mensajes;
using Abstracciones.LN.Interfaces.Mensajes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LN.Mensajes
{
    public class MensajeService : IMensajeService
    {
        private readonly IMensajeRepositorio _mensajeRepositorio;

        public MensajeService(IMensajeRepositorio mensajeRepositorio)
        {
            _mensajeRepositorio = mensajeRepositorio;
        }
        public async Task GuardarMensajeAsync(string numeroRemitente, string contenido)
        {
            if (string.IsNullOrEmpty(numeroRemitente) || string.IsNullOrEmpty(contenido))
                throw new ArgumentException("El número y el contenido no pueden estar vacíos.");

            await _mensajeRepositorio.GuardarMensajeAsync(numeroRemitente, contenido, DateTime.UtcNow);
        }

    }
}
