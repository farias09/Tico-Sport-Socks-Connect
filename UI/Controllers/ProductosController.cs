using Abstracciones.LN.Interfaces.Categorias.ListarCategorias;
using Abstracciones.LN.Interfaces.Productos.ActualizarProducto;
using Abstracciones.LN.Interfaces.Productos.CambiarEstado;
using Abstracciones.LN.Interfaces.Productos.CrearProducto;
using Abstracciones.LN.Interfaces.Productos.ListarProducto;
using Abstracciones.LN.Interfaces.Productos.ObtenerPorId;
using Abstracciones.Modelos.Productos;
using iTextSharp.text.pdf;
using iTextSharp.text;
using LN.Categorias.ListarCategorias;
using LN.Productos.ActualizarProducto;
using LN.Productos.CambiarEstado;
using LN.Productos.CrearProducto;
using LN.Productos.ListarProductos;
using LN.Productos.ObtenerPorId;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ClosedXML.Excel;
using System.Net;

namespace UI.Controllers
{
    public class ProductosController : Controller
    {
        ICrearProductoLN _crearProducto;
        IListarProductoLN _listarProducto;
        IListarCategoriasLN _listarCategorias;
        IActualizarProductoLN _actualizarProducto;
        IObtenerProductoPorIdLN _obtenerPorId;
        ICambiarEstadoProductoLN _cambiarEstado;

        public ProductosController() 
        {
            _crearProducto = new CrearProductoLN();
            _listarProducto = new ListarProductoLN();
            _listarCategorias = new ListarCategoriasLN();
            _actualizarProducto = new ActualizarProductoLN();
            _obtenerPorId = new ObtenerProductoPorIdLN();
            _cambiarEstado = new CambiarEstadoProductoLN();
        }
        
        // GET: Productos
        public ActionResult Index(string nombre, int categoriaId = 0, bool estado = true, string ordenStock = "")
        {
            List<ProductosDto> laListaDeProductos = _listarProducto.Listar();

            var categorias = _listarCategorias.Listar() 
        .Select(c => new SelectListItem
        {
            Value = c.Categoria_ID.ToString(),
            Text = c.nombre
        }).ToList();

            ViewBag.Categorias = categorias;

            if (!string.IsNullOrEmpty(nombre))
            {
                laListaDeProductos = laListaDeProductos
                    .Where(p => p.nombre.ToLower().Contains(nombre.ToLower()))
                    .ToList();
            }

            if (categoriaId > 0) 
            {
                laListaDeProductos = laListaDeProductos
                    .Where(p => p.Categoria_ID == categoriaId)
                    .ToList();
            }

            laListaDeProductos = laListaDeProductos
                .Where(p => p.Estado == estado)
                .ToList();

            if (!string.IsNullOrEmpty(ordenStock))
            {
                if (ordenStock == "asc")
                {
                    laListaDeProductos = laListaDeProductos.OrderBy(p => p.stock).ToList();
                }
                else if (ordenStock == "desc")
                {
                    laListaDeProductos = laListaDeProductos.OrderByDescending(p => p.stock).ToList();
                }
            }

            ViewBag.Nombre = nombre;
            ViewBag.CategoriaId = categoriaId;
            ViewBag.Estado = estado;
            ViewBag.OrdenStock = ordenStock;

            return View(laListaDeProductos);
        }

        // GET: Productos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Productos/Create
        public ActionResult CrearProducto()
        {
            return View();
        }

        // POST: Productos/Create
        [HttpPost]
        public async Task<ActionResult> CrearProducto(ProductosDto modeloDelProducto, HttpPostedFileBase imagenArchivo)
        {
            try
            {
                // Validar código duplicado
                var productoExiste = _listarProducto.Listar()
                    .FirstOrDefault(elCodigo => elCodigo.CodigoDelProducto == modeloDelProducto.CodigoDelProducto);

                if (productoExiste != null)
                {
                    ViewBag.MensajeDeError = "El código del producto ingresado ya está registrado.";
                    return View(modeloDelProducto);
                }

                // Procesar la imagen
                if (imagenArchivo != null && imagenArchivo.ContentLength > 0)
                {
                    // Crear directorio si no existe
                    string uploadDir = Server.MapPath("~/Content/Uploads/Productos");
                    if (!Directory.Exists(uploadDir))
                    {
                        Directory.CreateDirectory(uploadDir);
                    }

                    // Generar nombre único para el archivo
                    string fileName = Path.GetFileNameWithoutExtension(imagenArchivo.FileName);
                    string extension = Path.GetExtension(imagenArchivo.FileName);
                    fileName = $"{fileName}_{DateTime.Now:yyyyMMddHHmmss}{extension}";
                    string filePath = Path.Combine(uploadDir, fileName);

                    // Guardar el archivo
                    imagenArchivo.SaveAs(filePath);

                    // Guardar la ruta relativa en el modelo
                    modeloDelProducto.imagen = "/Content/Uploads/Productos/" + fileName;
                }
                else
                {
                    ModelState.AddModelError("imagenArchivo", "Debe seleccionar una imagen para el producto");
                    return View(modeloDelProducto);
                }

                // Guardar el producto
                int cantidadDeDatosGuardados = await _crearProducto.Guardar(modeloDelProducto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrió un error al crear el producto: " + ex.Message);
                return View(modeloDelProducto);
            }
        }

        // GET: Productos/Edit/5
        [HttpPost]
        public async Task<ActionResult> ActualizarProducto(ProductosDto elProducto, HttpPostedFileBase imagenArchivo)
        {
            try
            {
                // Validar código duplicado
                var existeProducto = _listarProducto.Listar();
                bool codigoDuplicado = existeProducto
                    .Any(elProductoValido => elProductoValido.CodigoDelProducto == elProducto.CodigoDelProducto &&
                                             elProductoValido.Producto_ID != elProducto.Producto_ID);

                if (codigoDuplicado)
                {
                    return Json(new { success = false, message = "Ya existe un producto con este código." });
                }

                // Procesar imagen solo si se subió un nuevo archivo
                if (imagenArchivo != null && imagenArchivo.ContentLength > 0)
                {
                    // Eliminar imagen anterior si existe
                    if (!string.IsNullOrEmpty(elProducto.imagen))
                    {
                        string oldFilePath = Server.MapPath(elProducto.imagen);
                        if (System.IO.File.Exists(oldFilePath))
                        {
                            System.IO.File.Delete(oldFilePath);
                        }
                    }

                    // Guardar nueva imagen
                    string uploadDir = Server.MapPath("~/Content/Uploads/Productos");
                    if (!Directory.Exists(uploadDir))
                    {
                        Directory.CreateDirectory(uploadDir);
                    }

                    string fileName = Path.GetFileNameWithoutExtension(imagenArchivo.FileName);
                    string extension = Path.GetExtension(imagenArchivo.FileName);
                    fileName = $"{fileName}_{DateTime.Now:yyyyMMddHHmmss}{extension}";
                    string filePath = Path.Combine(uploadDir, fileName);

                    imagenArchivo.SaveAs(filePath);
                    elProducto.imagen = "/Content/Uploads/Productos/" + fileName;
                }
                else
                {
                    // Mantener la imagen actual si no se subio una nueva
                    var productoActual = _obtenerPorId.Obtener(elProducto.Producto_ID);
                    if (productoActual != null)
                    {
                        elProducto.imagen = productoActual.imagen;
                    }
                }

                int cantidadDeDatosActualizados = await _actualizarProducto.Editar(elProducto);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error al actualizar: " + ex.Message });
            }
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Productos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public async Task<ActionResult> Activar(int id)
        {
            try
            {
                bool resultado = await _cambiarEstado.CambiarEstado(id, true);

                if (resultado)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Mensaje = "No se pudo activar el producto.";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Ocurrió un error inesperado: " + ex.Message;
                return RedirectToAction("Index");
            }
        }

        public async Task<ActionResult> Inactivar(int id)
        {
            try
            {
                bool resultado = await _cambiarEstado.CambiarEstado(id, false);

                if (resultado)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Mensaje = "No se pudo inactivar el producto.";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Ocurrió un error inesperado: " + ex.Message;
                return RedirectToAction("Index");
            }
        }

        private async Task VerificarYActualizarEstadoProducto(int productoId)
        {
            var producto = _obtenerPorId.Obtener(productoId);

            if (producto != null)
            {
                if (producto.stock == 0)
                {
                    bool resultado = await _cambiarEstado.CambiarEstado(productoId, false);
                    if (resultado)
                    {
                        TempData["Notificacion"] = $"El producto {producto.nombre} ha sido inactivado debido a la falta de stock.";
                    }
                }
                else
                {
                    TempData.Remove("Notificacion");
                }
            }
        }

        public ActionResult ExportarPDF(string nombre, int categoriaId = 0, bool estado = true, string ordenStock = "")
        {
            var productos = ObtenerProductosFiltrados(nombre, categoriaId, estado, ordenStock);
            string fechaRecuperacion = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            using (MemoryStream stream = new MemoryStream())
            {
                Document document = new Document(PageSize.A4.Rotate(), 25, 25, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(document, stream);

                // Agregar evento para numeración de páginas
                writer.PageEvent = new PdfPageEventHelper();

                document.Open();

                // Logo de la empresa
                string logoPath = Server.MapPath("~/Content/images/LOGOTSS.png");
                if (System.IO.File.Exists(logoPath))
                {
                    Image logo = Image.GetInstance(logoPath);
                    logo.ScaleAbsolute(100, 50);
                    logo.Alignment = Image.ALIGN_RIGHT;
                    document.Add(logo);
                }

                // Título
                Paragraph titulo = new Paragraph("Reporte de Inventario - Tico Sport Socks Connect",
                    new Font(Font.FontFamily.HELVETICA, 18, Font.BOLD));
                titulo.Alignment = Element.ALIGN_CENTER;
                document.Add(titulo);

                // Fecha de recuperación
                Paragraph fecha = new Paragraph($"Fecha de generación: {fechaRecuperacion}",
                    new Font(Font.FontFamily.HELVETICA, 10));
                fecha.Alignment = Element.ALIGN_LEFT;
                document.Add(fecha);

                // Filtros aplicados
                Paragraph filtros = new Paragraph($"Filtros: Nombre: {nombre ?? "Todos"}, Categoría: {categoriaId}, Estado: {(estado ? "Activo" : "Inactivo")}, Orden: {ordenStock}",
                    new Font(Font.FontFamily.HELVETICA, 10));
                filtros.Alignment = Element.ALIGN_LEFT;
                document.Add(filtros);

                // Espacio
                document.Add(new Paragraph(" "));

                // Tabla de productos (ahora con 8 columnas incluyendo imagen)
                PdfPTable table = new PdfPTable(8);
                table.WidthPercentage = 100;
                table.SetWidths(new float[] { 2f, 2f, 1f, 1f, 1f, 1f, 1f, 1.5f });

                // Encabezados
                Font headerFont = new Font(Font.FontFamily.HELVETICA, 10, Font.BOLD);
                table.AddCell(new PdfPCell(new Phrase("Nombre", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                table.AddCell(new PdfPCell(new Phrase("Descripción", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                table.AddCell(new PdfPCell(new Phrase("Precio", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                table.AddCell(new PdfPCell(new Phrase("Stock", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                table.AddCell(new PdfPCell(new Phrase("Imagen", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                table.AddCell(new PdfPCell(new Phrase("Categoría", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                table.AddCell(new PdfPCell(new Phrase("Estado", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                table.AddCell(new PdfPCell(new Phrase("Código", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });

                // Configuración para imágenes
                float maxImageHeight = 50f; // Altura máxima de la imagen en puntos (1 punto = 1/72 pulgadas)

                // Datos
                Font cellFont = new Font(Font.FontFamily.HELVETICA, 9);
                foreach (var producto in productos)
                {
                    // Nombre
                    table.AddCell(new PdfPCell(new Phrase(producto.nombre, cellFont)));

                    // Descripción
                    table.AddCell(new PdfPCell(new Phrase(producto.descripcion, cellFont)));

                    // Precio
                    table.AddCell(new PdfPCell(new Phrase(producto.precio.ToString("₡#,##0.00"), cellFont)));

                    // Stock
                    table.AddCell(new PdfPCell(new Phrase(producto.stock.ToString(), cellFont)));

                    // Imagen (celda especial)
                    PdfPCell imageCell = new PdfPCell();
                    if (!string.IsNullOrEmpty(producto.imagen))
                    {
                        try
                        {
                            // Si la imagen es una URL
                            if (Uri.IsWellFormedUriString(producto.imagen, UriKind.Absolute))
                            {
                                using (WebClient webClient = new WebClient())
                                {
                                    byte[] imageBytes = webClient.DownloadData(producto.imagen);
                                    using (MemoryStream imageStream = new MemoryStream(imageBytes))
                                    {
                                        Image image = Image.GetInstance(imageStream);

                                        // Escalar la imagen manteniendo la relación de aspecto
                                        if (image.Height > maxImageHeight)
                                        {
                                            float ratio = maxImageHeight / image.Height;
                                            image.ScaleAbsolute(image.Width * ratio, maxImageHeight);
                                        }

                                        imageCell.AddElement(image);
                                    }
                                }
                            }
                            else if (System.IO.File.Exists(Server.MapPath(producto.imagen)))
                            {
                                // Si la imagen es una ruta local
                                Image image = Image.GetInstance(Server.MapPath(producto.imagen));

                                // Escalar la imagen
                                if (image.Height > maxImageHeight)
                                {
                                    float ratio = maxImageHeight / image.Height;
                                    image.ScaleAbsolute(image.Width * ratio, maxImageHeight);
                                }

                                imageCell.AddElement(image);
                            }
                        }
                        catch
                        {
                            // Si hay algún error al cargar la imagen, mostramos un texto alternativo
                            imageCell.AddElement(new Phrase("Imagen no disponible", cellFont));
                        }
                    }
                    else
                    {
                        imageCell.AddElement(new Phrase("Sin imagen", cellFont));
                    }

                    table.AddCell(imageCell);

                    // Categoría
                    table.AddCell(new PdfPCell(new Phrase(producto.Categoria_ID.ToString(), cellFont)));

                    // Estado
                    table.AddCell(new PdfPCell(new Phrase(producto.Estado ? "Activo" : "Inactivo", cellFont)));

                    // Código
                    table.AddCell(new PdfPCell(new Phrase(producto.CodigoDelProducto.ToString(), cellFont)));
                }

                document.Add(table);
                document.Close();

                return File(stream.ToArray(), "application/pdf", "Inventario.pdf");
            }
        }

        public ActionResult ExportarExcel(string nombre, int categoriaId = 0, bool estado = true, string ordenStock = "")
        {
            var productos = ObtenerProductosFiltrados(nombre, categoriaId, estado, ordenStock);
            string fechaGeneracion = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Inventario");

                // Título
                worksheet.Cell(1, 1).Value = "Reporte de Inventario - Tico Sport Socks Connect";
                worksheet.Range(1, 1, 1, 7).Merge().Style.Font.Bold = true;

                // Fecha de generación
                worksheet.Cell(2, 1).Value = $"Fecha de generación: {fechaGeneracion}";
                worksheet.Range(2, 1, 2, 7).Merge();

                // Filtros
                worksheet.Cell(3, 1).Value = $"Filtros: Nombre: {nombre ?? "Todos"}, Categoría: {categoriaId}, Estado: {(estado ? "Activo" : "Inactivo")}, Orden: {ordenStock}";
                worksheet.Range(3, 1, 3, 7).Merge();

                // Encabezados
                worksheet.Cell(5, 1).Value = "Nombre";
                worksheet.Cell(5, 2).Value = "Descripción";
                worksheet.Cell(5, 3).Value = "Precio";
                worksheet.Cell(5, 4).Value = "Stock";
                worksheet.Cell(5, 5).Value = "Categoría";
                worksheet.Cell(5, 6).Value = "Estado";
                worksheet.Cell(5, 7).Value = "Código";

                // Datos
                int row = 6;
                foreach (var producto in productos)
                {
                    worksheet.Cell(row, 1).Value = producto.nombre;
                    worksheet.Cell(row, 2).Value = producto.descripcion;
                    worksheet.Cell(row, 3).Value = producto.precio;
                    worksheet.Cell(row, 4).Value = producto.stock;
                    worksheet.Cell(row, 5).Value = producto.Categoria_ID;
                    worksheet.Cell(row, 6).Value = producto.Estado ? "Activo" : "Inactivo";
                    worksheet.Cell(row, 7).Value = producto.CodigoDelProducto;
                    row++;
                }

                // Formato
                worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Inventario.xlsx");
                }
            }
        }

        public ActionResult ExportarCSV(string nombre, int categoriaId = 0, bool estado = true, string ordenStock = "")
        {
            var productos = ObtenerProductosFiltrados(nombre, categoriaId, estado, ordenStock);
            string fechaGeneracion = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            var sb = new StringBuilder();

            // Fecha de generación
            sb.AppendLine($"Fecha de generación: {fechaGeneracion}");

            // Encabezados
            sb.AppendLine("Nombre,Descripción,Precio,Stock,Categoría,Estado,Código");

            // Datos
            foreach (var producto in productos)
            {
                sb.AppendLine($"\"{producto.nombre}\",\"{producto.descripcion}\",{producto.precio},{producto.stock},{producto.Categoria_ID},{(producto.Estado ? "Activo" : "Inactivo")},\"{producto.CodigoDelProducto}\"");
            }

            return File(Encoding.UTF8.GetBytes(sb.ToString()), "text/csv", "Inventario.csv");
        }

        private IEnumerable<ProductosDto> ObtenerProductosFiltrados(string nombre, int categoriaId, bool estado, string ordenStock)
        {
            var productos = _listarProducto.Listar();

            if (!string.IsNullOrEmpty(nombre))
            {
                productos = productos.Where(p => p.nombre.ToLower().Contains(nombre.ToLower())).ToList();
            }

            if (categoriaId > 0)
            {
                productos = productos.Where(p => p.Categoria_ID == categoriaId).ToList();
            }

            productos = productos.Where(p => p.Estado == estado).ToList();

            if (!string.IsNullOrEmpty(ordenStock))
            {
                productos = ordenStock == "asc"
                    ? productos.OrderBy(p => p.stock).ToList()
                    : productos.OrderByDescending(p => p.stock).ToList();
            }

            return productos;
        }

    }
}