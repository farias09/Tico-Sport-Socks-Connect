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

        /*[System.Web.Http.HttpPost]
        [System.Web.Http.Route("webhook")]
        public async Task<IHttpActionResult> ReceiveWhatsAppMessage([FromBody] Dictionary<string, string> formData)
        {
            try
            {
                Console.WriteLine("📩 Webhook recibido.");

                if (formData == null)
                {
                    Console.WriteLine("❌ Error: No se recibieron datos en la solicitud.");
                    return BadRequest("No se recibieron datos en la solicitud.");
                }

                if (!formData.ContainsKey("From") || !formData.ContainsKey("Body"))
                {
                    Console.WriteLine("❌ Error: Faltan datos.");
                    return BadRequest("Faltan datos en la solicitud.");
                }

                string numeroRemitente = formData["From"];
                string contenido = formData["Body"];

                Console.WriteLine($"📩 Mensaje recibido de {numeroRemitente}: {contenido}");

                // Guardar en la base de datos
                await _mensajeService.GuardarMensajeAsync(numeroRemitente, contenido);

                // Responder a Twilio con confirmación
                var response = new MessagingResponse();
                response.Message("Mensaje recibido correctamente.");

                return Ok(response.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error en el webhook: {ex.Message}");
                return InternalServerError(ex);
            }
        }*/

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
                 await _mensajeService.GuardarMensajeAsync(numeroRemitente, contenido);

                 var response = new MessagingResponse();
                 response.Message("Mensaje recibido y guardado correctamente.");

                 return Ok(response.ToString());
             }
             catch (Exception ex)
             {
                 Trace.TraceError($"❌ Error en el webhook: {ex.ToString()}");
                 return InternalServerError(ex);
             }
         } 

        /*[System.Web.Http.HttpPost]
        [System.Web.Http.Route("webhook")]
        public async Task<IHttpActionResult> ReceiveWhatsAppMessage()
        {
            try
            {
                // 🔹 Leer el contenido del request manualmente
                var content = await Request.Content.ReadAsStringAsync();
                Console.WriteLine($"📩 Datos crudos recibidos: {content}");

                // 🔹 Verificar si el contenido está vacío
                if (string.IsNullOrEmpty(content))
                {
                    Console.WriteLine("❌ Error: No se recibió contenido en la solicitud.");
                    return BadRequest("No se recibió contenido en la solicitud.");
                }

                // 🔹 Convertir los datos de Twilio en un diccionario
                var form = System.Web.HttpUtility.ParseQueryString(content);

                // 🔹 Extraer valores
                string numeroRemitente = form["From"];
                string contenidoMensaje = form["Body"];

                Console.WriteLine($"📩 Mensaje recibido de {numeroRemitente}: {contenidoMensaje}");

                return Ok("✅ Recibido correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error en el webhook: {ex.Message}");
                return InternalServerError(ex);
            }
        }*/

    }
}
