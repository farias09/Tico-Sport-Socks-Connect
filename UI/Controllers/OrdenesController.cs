using Abstracciones.Modelos.Ordenes;
using AccesoADatos;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using LN.Cajas.ListarCaja;
using LN.General.Conversiones.Cajas.ConvertirACajasDto;
using LN.Ordenes.OrdenService;
using LN.Productos.ListarProductos;
using LN.Usuarios.ListarUsuario;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Mvc;
using UI.Models;


namespace UI.Controllers
{
    public class OrdenesController : Controller
    {
        private readonly OrdenService _ordenService;
        private readonly ListarProductoLN _listarProductoLN;
        private readonly ListarUsuarioLN _listarUsuarioLN;
        private readonly ListarCajaLN _listarCajaLN;

        public OrdenesController()
        {
            _ordenService = new OrdenService(new AcessoADatos.Ordenes.OrdenRepositorio());
            _listarProductoLN = new ListarProductoLN();
            _listarUsuarioLN = new ListarUsuarioLN(new AcessoADatos.Usuarios.ListarUsuario.ListarUsuarioAD(new Contexto()), null);
            _listarCajaLN = new ListarCajaLN(new AcessoADatos.Cajas.ListarCaja.ListarCajaAD(new Contexto()), new ConvertirACajasDto());
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

        public ActionResult OrdenesPendientes()
        {
            var ordenes = _ordenService.ObtenerOrdenes();
            var detalles = new List<DetalleOrdenesDto>();
            var usuarios = new Dictionary<int, string>();

            foreach (var orden in ordenes)
            {
                detalles.AddRange(_ordenService.ObtenerDetallesPorOrden(orden.Orden_ID));

                // Obtener el nombre del usuario si no está en el diccionario
                if (!usuarios.ContainsKey(orden.Usuario_ID))
                {
                    var usuario = _listarUsuarioLN.ObtenerUsuarioPorId(orden.Usuario_ID);
                    usuarios.Add(orden.Usuario_ID, usuario?.Nombre ?? "Cliente no encontrado");
                }
            }

            ViewBag.Detalles = detalles;
            ViewBag.Usuarios = usuarios;
            return View(ordenes);
        }

        [HttpPost]
        public ActionResult CambiarEstadoOrden(int id, string estado)
        {
            try
            {
                var orden = _ordenService.ObtenerOrdenPorId(id);
                if (orden == null)
                {
                    return Json(new { success = false, message = "Orden no encontrada" });
                }

                // Actualizar el estado en la base de datos
                var contexto = new Contexto();
                var ordenDb = contexto.OrdenesTabla.FirstOrDefault(o => o.Orden_ID == id);
                if (ordenDb != null)
                {
                    ordenDb.Estado = estado;
                    contexto.SaveChanges();
                }

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public ActionResult VentaFisica()
        {
            var productosActivos = _listarProductoLN.Listar().Where(p => p.Estado).ToList();
            ViewBag.ProductosActivos = productosActivos;
            return View();
        }

        public ActionResult DetalleProducto(int id)
        {
            // Obtener el producto por su ID
            var producto = _listarProductoLN.Listar().FirstOrDefault(p => p.Producto_ID == id);

            if (producto == null)
            {
                return HttpNotFound();
            }

            // Pasar el producto a la vista
            return View(producto);
        }

        public ActionResult Create()
        {
            var cajas = _listarCajaLN.Listar();
            ViewBag.Cajas = new SelectList(cajas, "Caja_ID", "nombre_caja");

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
        public ActionResult Create(OrdenViewModel model)
        {
            var cajas = _listarCajaLN.Listar();
            ViewBag.Cajas = new SelectList(cajas, "Caja_ID", "nombre_caja");

            if (ModelState.IsValid)
            {
                // Deserializar los productos seleccionados del JSON
                var detalles = JsonConvert.DeserializeObject<List<dynamic>>(Request.Form["ProductosSeleccionadosJson"]);

                // Calcular el total de la orden
                decimal totalOrden = 0;

                // Crear una lista de DetalleOrdenesDto con la información completa
                var detallesOrdenes = new List<DetalleOrdenesDto>();

                foreach (var detalle in detalles)
                {
                    // Convertir los detalles dinámicos a DetalleOrdenesDto con todos los campos necesarios
                    var detalleOrden = new DetalleOrdenesDto
                    {
                        Producto_ID = Convert.ToInt32(detalle.Producto_ID),
                        Cantidad = Convert.ToInt32(detalle.Cantidad),
                        Subtotal = Convert.ToDecimal(detalle.Subtotal),
                        NombreProducto = detalle.Nombre.ToString(), // Guardar el nombre del producto
                        PrecioUnitario = Convert.ToInt32(detalle.Precio) // Guardar el precio unitario
                    };

                    detallesOrdenes.Add(detalleOrden);
                    totalOrden += detalleOrden.Subtotal;
                }

                // Asignar el total calculado a la orden
                model.Orden.Total = totalOrden;
                model.Orden.FechaOrden = DateTime.Now;
                model.Orden.Estado = "Pendiente";

                // Crear la orden con los detalles completos
                var ordenCreada = _ordenService.CrearOrden(model.Orden, detallesOrdenes);

                if (ordenCreada == null || ordenCreada.Orden_ID == 0)
                {
                    ModelState.AddModelError("", "Hubo un error al crear la orden.");
                    return View(model);
                }

                return RedirectToAction("Confirmacion", new { id = ordenCreada.Orden_ID });
            }

            var usuarios = _listarUsuarioLN.Listar();
            ViewBag.Usuarios = new SelectList(usuarios, "Usuario_ID", "Nombre");

            model.Productos = _listarProductoLN.Listar();
            return View(model);
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
                if (string.IsNullOrWhiteSpace(correo))
                {
                    return Json(new { success = false, message = "El correo electrónico es requerido" });
                }

                if (string.IsNullOrWhiteSpace(facturaHtml))
                {
                    return Json(new { success = false, message = "El contenido de la factura es requerido" });
                }

                // Validar formato de correo
                try
                {
                    var mailAddress = new System.Net.Mail.MailAddress(correo);
                }
                catch
                {
                    return Json(new { success = false, message = "El formato del correo electrónico no es válido" });
                }

                Task.Run(() => EnviarFacturaAsync(correo, facturaHtml));

                return Json(new
                {
                    success = true,
                    message = "La factura está siendo procesada y será enviada al correo electrónico proporcionado."
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = "Error interno al procesar la solicitud: " + ex.Message
                });
            }
        }

        // Proceso asincronico
        private async Task EnviarFacturaAsync(string correo, string facturaHtml)
        {
            MailMessage mailMessage = null;
            Attachment attachment = null;
            MemoryStream stream = null;

            try
            {
                byte[] pdfBytes = GenerarPDF(facturaHtml);

                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("brianvargas570@gmail.com", "vvpudyarvqzjaafk"),
                    EnableSsl = true,
                    Timeout = 10000,
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };

                mailMessage = new MailMessage
                {
                    From = new MailAddress("brianvargas570@gmail.com"),
                    Subject = "Factura de Compra - Tico Sport Socks",
                    Body = "Estimado cliente,\n\nAdjunto encontrarás la factura de tu compra.\n\nGracias por tu preferencia.\n\nAtentamente,\nTico Sport Socks",
                    IsBodyHtml = false,
                    Priority = MailPriority.High
                };

                mailMessage.To.Add(correo);

                string nombreArchivo = $"Factura_TSS_{DateTime.Now:yyyyMMddHHmmss}.pdf";
                stream = new MemoryStream(pdfBytes);
                attachment = new Attachment(stream, nombreArchivo, "application/pdf");
                mailMessage.Attachments.Add(attachment);

                await smtpClient.SendMailAsync(mailMessage);
            }
            catch (SmtpException smtpEx)
            {
                System.Diagnostics.Debug.WriteLine($"Error SMTP: {smtpEx.StatusCode} - {smtpEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error general: {ex.Message}");
                throw;
            }
            finally
            {
                attachment?.Dispose();
                stream?.Dispose();
                mailMessage?.Dispose();
            }
        }



        public ActionResult UltimasOrdenes()
        {
            Func<int, string> obtenerNombreUsuario = id =>
            _listarUsuarioLN.ObtenerUsuarioPorId(id)?.Nombre ?? "Desconocido";

            Func<int?, string> obtenerNombreCaja = id =>
            {
                if (id == null) return "N/A";
                var caja = _listarCajaLN.ObtenerCajaPorId(id.Value);
                return caja?.nombre_caja ?? "Desconocida";
            };

            var resumen = _ordenService.ObtenerUltimasOrdenesConDetalles(obtenerNombreUsuario, obtenerNombreCaja);
            return View(resumen);
        }

        [HttpGet]
        public ActionResult ConsultarFactura()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ObtenerFacturaOrden(int id)
        {
            var orden = _ordenService.ObtenerOrdenPorId(id);
            if (orden == null) return Json(new { success = false, message = "Orden no encontrada" }, JsonRequestBehavior.AllowGet);

            var detalles = _ordenService.ObtenerDetallesPorOrden(id);
            var usuario = _listarUsuarioLN.ObtenerUsuarioPorId(orden.Usuario_ID);

            return Json(new
            {
                success = true,
                orden = new
                {
                    orden.Orden_ID,
                    orden.FechaOrden,
                    orden.Total,
                    orden.Estado
                },
                cliente = new
                {
                    usuario.Nombre,
                    usuario.Email
                },
                productos = detalles.Select(d => new {
                    d.NombreProducto,
                    d.Cantidad,
                    d.PrecioUnitario,
                    d.Subtotal
                })
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GestionFacturas()
        {
            var ordenes = _ordenService.ObtenerOrdenes();
            var usuarios = _listarUsuarioLN.Listar();

            var resumen = ordenes.Select(o => new OrdenResumenDto
            {
                Orden_ID = o.Orden_ID,
                UsuarioNombre = usuarios.FirstOrDefault(u => u.Usuario_ID == o.Usuario_ID)?.Nombre ?? "Desconocido",
                FechaOrden = o.FechaOrden,
                Total = o.Total,
                Estado = o.Estado
            }).OrderByDescending(o => o.FechaOrden).ToList();

            ViewBag.TotalOrdenes = resumen.Count;
            ViewBag.Pendientes = resumen.Count(o => o.Estado == "Pendiente");
            ViewBag.Completadas = resumen.Count(o => o.Estado == "Completado");
            ViewBag.UltimaOrden = resumen.FirstOrDefault();

            return View(resumen);
        }
    }
}