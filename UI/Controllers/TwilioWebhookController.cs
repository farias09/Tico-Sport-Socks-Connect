using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using Abstracciones;
using Abstracciones.LN.Interfaces.Mensajes;
using Twilio.TwiML;

namespace UI.Controllers
{
    [System.Web.Http.RoutePrefix("api/twilio")]
    public class TwilioWebhookController : ApiController
    {
        private readonly IMensajeService _mensajeService;

        public TwilioWebhookController(IMensajeService mensajeService)
        {
            _mensajeService = mensajeService ?? throw new ArgumentNullException(nameof(mensajeService));
            Console.WriteLine("TwilioWebhookController ha sido instanciado correctamente.");

        }

         [System.Web.Http.HttpPost]
         [System.Web.Http.Route("webhook")]
         public async Task<IHttpActionResult> ReceiveWhatsAppMessage()
         {
            var form = await Request.Content.ReadAsFormDataAsync();

             string numeroRemitente = form["From"];
             string contenido = form["Body"];

             Console.WriteLine($"📩 Mensaje recibido de {numeroRemitente}: {contenido}");

             if (string.IsNullOrEmpty(numeroRemitente) || string.IsNullOrEmpty(contenido))
                 return BadRequest("Datos incompletos.");

             try
             {
                Console.WriteLine("Llamando al servicio para guardar el mensaje...");
                await _mensajeService.GuardarMensajeAsync(numeroRemitente, contenido);
                Console.WriteLine("✅ Mensaje guardado (o al menos el método fue ejecutado).");

                var response = new MessagingResponse();
                 response.Message("Mensaje recibido y guardado correctamente.");

                 return Ok(response.ToString());
             }
             catch (Exception ex)
             {
                 Trace.TraceError($"❌ Error en el webhook: {ex.ToString()}");
                Console.WriteLine($"❌ ERROR guardando el mensaje: {ex.Message}");
                return InternalServerError(ex);
             }
         } 
    }
}
