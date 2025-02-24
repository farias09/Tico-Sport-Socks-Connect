using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.AD.Interfaces.Mensajes
{
    public interface IMensajeRepositorio
    {
        Task GuardarMensajeAsync(string numeroRemitente, string contenido, DateTime fecha);
    }
}
