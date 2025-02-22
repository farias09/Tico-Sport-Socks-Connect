using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.LN.Interfaces.Mensajes
{
    public interface IMensajeService
    {
        Task GuardarMensajeAsync(string numeroRemitente, string contenido);
    }
}
