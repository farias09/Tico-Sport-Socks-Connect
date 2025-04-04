using AcessoADatos.Ordenes;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.tool.xml;
using LN.Ordenes.OrdenService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using OfficeOpenXml;

namespace UI.Controllers
{
    public class ReportesController : Controller
    {
        private readonly OrdenService _ordenService;

        public ReportesController()
        {
            _ordenService = new OrdenService(new OrdenRepositorio());
        }

        public ActionResult Index(DateTime? fechaInicio, DateTime? fechaFin)
        {
            var ventasPorMes = _ordenService.ObtenerVentasPorMes();
            ViewBag.VentasMensuales = ventasPorMes;

            var ventasPorTipo = _ordenService.ObtenerVentasPorTipo();
            ViewBag.VentasPorTipo = ventasPorTipo;

            var productosMasVendidos = _ordenService.ObtenerProductosMasVendidos();
            ViewBag.ProductosMasVendidos = productosMasVendidos;

            var ventasPorUsuario = _ordenService.ObtenerVentasPorUsuario();
            ViewBag.VentasPorUsuario = ventasPorUsuario;

            var ventas = _ordenService.ObtenerVentasPorDia(fechaInicio, fechaFin);
            ViewBag.FechaInicio = fechaInicio?.ToString("yyyy-MM-dd");
            ViewBag.FechaFin = fechaFin?.ToString("yyyy-MM-dd");

            return View(ventas);
        }

        [HttpGet]
        public ActionResult ExportarVentasPorDiaPdf(DateTime? fechaInicio, DateTime? fechaFin)
        {
            var ventas = _ordenService.ObtenerVentasPorDia(fechaInicio, fechaFin);

            StringBuilder html = new StringBuilder();

            html.Append("<h2 style='text-align:center; font-family:Arial; color:#0d6efd;'>Reporte de Ventas por Día</h2>");

            html.Append("<table style='width:100%; border-collapse:collapse; font-family:Arial; font-size:14px;'>");
            html.Append("<thead>");
            html.Append("<tr style='background-color:#0d6efd; color:white;'>");
            html.Append("<th style='padding:10px; border:1px solid #ccc;'>Fecha</th>");
            html.Append("<th style='padding:10px; border:1px solid #ccc;'>Total Vendido</th>");
            html.Append("</tr>");
            html.Append("</thead><tbody>");

            foreach (var item in ventas)
            {
                html.Append("<tr>");
                html.AppendFormat("<td style='padding:8px; border:1px solid #eee;'>{0}</td>", item.Fecha.ToString("dd/MM/yyyy"));
                html.AppendFormat("<td style='padding:8px; border:1px solid #eee; text-align:right;'>₡{0:N0}</td>", item.TotalVentas);
                html.Append("</tr>");
            }

            html.Append("</tbody></table>");

            byte[] pdfBytes = GenerarPDFDesdeHtml(html.ToString());
            return File(pdfBytes, "application/pdf", "Reporte_VentasPorDia.pdf");
        }


        private byte[] GenerarPDFDesdeHtml(string html)
        {
            using (var ms = new MemoryStream())
            {
                var document = new Document(PageSize.A4, 25, 25, 25, 25);
                var writer = PdfWriter.GetInstance(document, ms);
                document.Open();

                using (var sr = new StringReader(html))
                {
                    XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, sr);
                }

                document.Close();
                return ms.ToArray();
            }
        }

        [HttpGet]
        public ActionResult ExportarVentasPorUsuarioPdf()
        {
            var ventas = _ordenService.ObtenerVentasPorUsuario();

            StringBuilder html = new StringBuilder();

            html.Append("<h2 style='text-align:center; font-family:Arial; color:#198754;'>Reporte de Ventas por Usuario</h2>");

            html.Append("<table style='width:100%; border-collapse:collapse; font-family:Arial; font-size:14px;'>");

            html.Append("<thead>");
            html.Append("<tr style='background-color:#198754; color:white;'>");
            html.Append("<th style='padding:10px; border:1px solid #ccc;'>Usuario</th>");
            html.Append("<th style='padding:10px; border:1px solid #ccc;'>Total Vendido</th>");
            html.Append("</tr>");
            html.Append("</thead><tbody>");

            foreach (var item in ventas)
            {
                html.Append("<tr>");
                html.AppendFormat("<td style='padding:8px; border:1px solid #eee;'>{0}</td>", item.UsuarioNombre);
                html.AppendFormat("<td style='padding:8px; border:1px solid #eee; text-align:right;'>₡{0:N0}</td>", item.TotalVentas);
                html.Append("</tr>");
            }

            html.Append("</tbody></table>");

            byte[] pdfBytes = GenerarPDFDesdeHtml(html.ToString());
            return File(pdfBytes, "application/pdf", "Reporte_VentasPorUsuario.pdf");
        }


        [HttpGet]
        public ActionResult ExportarProductosMasVendidosPdf()
        {
            var productos = _ordenService.ObtenerProductosMasVendidos();

            StringBuilder html = new StringBuilder();

            html.Append("<h2 style='text-align:center; font-family:Arial; color:#6610f2;'>Reporte de Productos Más Vendidos</h2>");

            html.Append("<table style='width:100%; border-collapse:collapse; font-family:Arial; font-size:14px;'>");

            html.Append("<thead>");
            html.Append("<tr style='background-color:#6610f2; color:white;'>");
            html.Append("<th style='padding:10px; border:1px solid #ccc;'>Producto</th>");
            html.Append("<th style='padding:10px; border:1px solid #ccc;'>Cantidad Vendida</th>");
            html.Append("<th style='padding:10px; border:1px solid #ccc;'>Total Generado</th>");
            html.Append("</tr>");
            html.Append("</thead><tbody>");

            foreach (var item in productos)
            {
                html.Append("<tr>");
                html.AppendFormat("<td style='padding:8px; border:1px solid #eee;'>{0}</td>", item.NombreProducto);
                html.AppendFormat("<td style='padding:8px; border:1px solid #eee; text-align:center;'>{0}</td>", item.CantidadVendida);
                html.AppendFormat("<td style='padding:8px; border:1px solid #eee; text-align:right;'>₡{0:N0}</td>", item.TotalGenerado);
                html.Append("</tr>");
            }

            html.Append("</tbody></table>");

            byte[] pdfBytes = GenerarPDFDesdeHtml(html.ToString());
            return File(pdfBytes, "application/pdf", "Reporte_ProductosMasVendidos.pdf");
        }


        [HttpGet]
        public ActionResult ExportarVentasPorTipoPdf()
        {
            var ventas = _ordenService.ObtenerVentasPorTipo();

            StringBuilder html = new StringBuilder();

            html.Append("<h2 style='text-align:center; font-family:Arial; color:#198754;'>Reporte de Ventas por Tipo</h2>");
            html.Append("<table style='width:100%; border-collapse:collapse; font-family:Arial; font-size:14px;'>");

            html.Append("<thead>");
            html.Append("<tr style='background-color:#198754; color:white;'>");
            html.Append("<th style='padding:10px; border:1px solid #ccc;'>Tipo de Venta</th>");
            html.Append("<th style='padding:10px; border:1px solid #ccc;'>Cantidad de Órdenes</th>");
            html.Append("<th style='padding:10px; border:1px solid #ccc;'>Total Vendido</th>");
            html.Append("</tr>");
            html.Append("</thead><tbody>");

            foreach (var item in ventas)
            {
                html.AppendFormat("<tr>");
                html.AppendFormat("<td style='padding:8px; border:1px solid #eee;'>{0}</td>", item.TipoVenta);
                html.AppendFormat("<td style='padding:8px; border:1px solid #eee; text-align:center;'>{0}</td>", item.CantidadOrdenes);
                html.AppendFormat("<td style='padding:8px; border:1px solid #eee; text-align:right;'>₡{0:N0}</td>", item.TotalVentas);
                html.AppendFormat("</tr>");
            }

            html.Append("</tbody></table>");

            byte[] pdfBytes = GenerarPDFDesdeHtml(html.ToString());
            return File(pdfBytes, "application/pdf", "Reporte_VentasPorTipo.pdf");
        }

        [HttpGet]
        public ActionResult ExportarVentasPorMesPdf()
        {
            var ventas = _ordenService.ObtenerVentasPorMes();

            StringBuilder html = new StringBuilder();
            html.Append("<h2 style='text-align:center;'>Reporte de Ventas por Mes</h2>");
            html.Append("<table border='1' width='100%' style='border-collapse:collapse;'>");
            html.Append("<thead><tr><th>Mes</th><th>Total Vendido</th></tr></thead><tbody>");

            foreach (var item in ventas)
            {
                html.AppendFormat("<tr><td>{0}</td><td>₡{1:N0}</td></tr>", item.Mes, item.TotalVentas);
            }

            html.Append("</tbody></table>");

            byte[] pdfBytes = GenerarPDFDesdeHtml(html.ToString());
            return File(pdfBytes, "application/pdf", "Reporte_VentasPorMes.pdf");
        }


    }
}
