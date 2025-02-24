using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abstracciones.LN.Interfaces.Carrito;
using Abstracciones.Modelos.Carrito;
using Abstracciones.Modelos.Ordenes;
using Abstracciones.Modelos.Productos;
using AcessoADatos;
using LN.Ordenes.OrdenService;
using Microsoft.Owin;
using LN.Productos.ListarProductos;
using UI.Models;
using LN.Usuarios.ListarUsuario;
using AccesoADatos;
using Newtonsoft.Json;
using System.Net.Mail;
using System.Net;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.Text;
using System.Threading.Tasks;

namespace UI.Controllers
{
    public class OrdenesController : Controller
    {
        private readonly OrdenService _ordenService;
        private readonly ListarProductoLN _listarProductoLN;
        private readonly ListarUsuarioLN _listarUsuarioLN;

        public OrdenesController()
        {
            _ordenService = new OrdenService(new AcessoADatos.Ordenes.OrdenRepositorio());
            _listarProductoLN = new ListarProductoLN();
            _listarUsuarioLN = new ListarUsuarioLN(new AcessoADatos.Usuarios.ListarUsuario.ListarUsuarioAD(new Contexto()), null);
        }

        public ActionResult Index()
        {
            var ordenes = _ordenService.ObtenerOrdenes();
            return View(ordenes);
        }

        public ActionResult DetallesChat()
        {
            return View();
        }

        public ActionResult VentaFisica()
        {
            var productosActivos = _listarProductoLN.Listar().Where(p => p.Estado).ToList();
            ViewBag.ProductosActivos = productosActivos;
            return View();
        }

        public ActionResult DetalleProducto()
        {
            return View();
        }

        public ActionResult Create()
        {
            var usuarios = _listarUsuarioLN.Listar();
            ViewBag.Usuarios = new SelectList(usuarios, "Usuario_ID", "Nombre");

            var productos = _listarProductoLN.Listar();
            var modelo = new OrdenViewModel
            {
                Orden = new OrdenesDto(),
                Productos = productos
            };
            return View(modelo);
        }

        [HttpPost]
        public ActionResult Create(OrdenesDto orden, string ProductosSeleccionadosJson)
        {
            if (ModelState.IsValid)
            {
                var detalles = JsonConvert.DeserializeObject<List<DetalleOrdenesDto>>(ProductosSeleccionadosJson);

                var ordenCreada = _ordenService.CrearOrden(orden, detalles);

                if (ordenCreada == null || ordenCreada.Orden_ID == 0)
                {
                    ModelState.AddModelError("", "Hubo un error al crear la orden.");
                    return View(orden);
                }

                return RedirectToAction("Confirmacion", new { id = ordenCreada.Orden_ID });
            }

            var usuarios = _listarUsuarioLN.Listar();
            ViewBag.Usuarios = new SelectList(usuarios, "Usuario_ID", "Nombre");

            var productos = _listarProductoLN.Listar();
            var modelo = new OrdenViewModel
            {
                Orden = orden,
                Productos = productos
            };

            return View(modelo);
        }

        public ActionResult Confirmacion(int id)
        {
            var orden = _ordenService.ObtenerOrdenPorId(id);
            var detalles = _ordenService.ObtenerDetallesPorOrden(id);
            var usuario = _listarUsuarioLN.ObtenerUsuarioPorId(orden.Usuario_ID);

            var viewModel = new OrdenViewModel
            {
                Orden = orden,
                Detalles = detalles,
                Usuario = usuario
            };

            return View(viewModel);
        }

        // Metodo para generar el PDF de la Factura
        private byte[] GenerarPDF(string htmlContent)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Document document = new Document(PageSize.A4, 25, 25, 25, 25);
                PdfWriter writer = PdfWriter.GetInstance(document, ms);

                writer.SetFullCompression();

                writer.CompressionLevel = PdfStream.BEST_SPEED;

                document.Open();

                using (StringReader sr = new StringReader(htmlContent))
                {
                    XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, sr);
                }

                document.Close();
                return ms.ToArray();
            }
        }

        // Metodo para enviar la factura por correo
        [HttpPost]
        public ActionResult EnviarFactura(string correo, string facturaHtml)
        {
            try
            {
                Task.Run(() => EnviarFacturaAsync(correo, facturaHtml));

                return Json(new { success = true, message = "Procesando su factura. En breve recibirá un correo con el detalle de su compra." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error al iniciar el proceso: " + ex.Message });
            }
        }

        // Proceso asincronico
        private async Task EnviarFacturaAsync(string correo, string facturaHtml)
        {
            try
            {
                byte[] pdfBytes = GenerarPDF(facturaHtml);

                // Configuración del servidor SMTP
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("brianvargas570@gmail.com", "vvpudyarvqzjaafk "),
                    EnableSsl = true,
                    Timeout = 10000, // 10 segundos de timeout
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };

                // Mensaje generico
                var mailMessage = new MailMessage
                {
                    From = new MailAddress("brianvargas570@gmail.com"),
                    Subject = "Factura de Compra - Tico Sport Socks",
                    Body = "Estimado cliente,<br/><br/>Adjunto encontrarás la factura digital de tu compra reciente en Tico Sport Socks.<br/><br/>Gracias por tu preferencia.<br/><br/>Atentamente,<br/>Equipo de Tico Sport Socks",
                    IsBodyHtml = true,
                    Priority = MailPriority.High
                };

                mailMessage.To.Add(correo);

                // Se adjunta el pdf de la factura
                string nombreArchivo = "Factura_TicoSportSocks.pdf";
                MemoryStream stream = new MemoryStream(pdfBytes);
                mailMessage.Attachments.Add(new Attachment(stream, nombreArchivo, "application/pdf"));

                await Task.Run(() => smtpClient.Send(mailMessage));

                // Limpieza
                mailMessage.Dispose();
                stream.Dispose();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error en envío asíncrono: " + ex.Message);
            }
        }
    }
}