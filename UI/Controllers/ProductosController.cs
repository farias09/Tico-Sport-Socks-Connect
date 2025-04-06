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
        public async Task<ActionResult> CrearProducto(ProductosDto modeloDelProducto)
        {
            try
            {
                var productoExiste = _listarProducto.Listar()
                    .FirstOrDefault(elCodigo => elCodigo.CodigoDelProducto == modeloDelProducto.CodigoDelProducto);

                if (productoExiste != null)
                {
                    ViewBag.MensajeDeError = "El codigo del producto ingresado ya está registrado.";
                    return View(modeloDelProducto);
                }

                int cantidadDeDatosGuardados = await _crearProducto.Guardar(modeloDelProducto);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Productos/Edit/5
        public ActionResult ActualizarProducto(int id)
        {
            ProductosDto elProducto = _obtenerPorId.Obtener(id);
            return View(elProducto);
        }

        // POST: Productos/Edit/5
        [HttpPost]
        public async Task<ActionResult> ActualizarProducto(ProductosDto elProducto)
        {
            try
            {
                var existeProducto = _listarProducto.Listar();
                bool codigoDuplicado = existeProducto
                    .Any(elProductoValido => elProductoValido.CodigoDelProducto == elProducto.CodigoDelProducto && elProductoValido.Producto_ID != elProducto.Producto_ID);

                if (codigoDuplicado)
                {
                    ModelState.AddModelError("CodigoDelProducto", "Ya existe ese codigo de producto.");
                    return View(elProducto);
                }
                else
                {
                    bool cambioEstado = await _cambiarEstado.CambiarEstado(elProducto.Producto_ID, elProducto.Estado);

                    if (!cambioEstado)
                    {
                        ModelState.AddModelError("", "No se pudo actualizar el estado del producto.");
                        return View(elProducto);
                    }

                    int cantidadDeDatosActualizados = await _actualizarProducto.Editar(elProducto);

                    await VerificarYActualizarEstadoProducto(elProducto.Producto_ID);

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrió un error al actualizar el producto: " + ex.Message);
                return View(elProducto);
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

            using (MemoryStream stream = new MemoryStream())
            {
                Document document = new Document(PageSize.A4.Rotate(), 25, 25, 30, 30); // Usamos horizontal para más espacio
                PdfWriter writer = PdfWriter.GetInstance(document, stream);
                document.Open();

                // Título
                Paragraph titulo = new Paragraph("Reporte de Inventario");
                titulo.Alignment = Element.ALIGN_CENTER;
                titulo.Font.Size = 18;
                document.Add(titulo);

                // Filtros aplicados
                Paragraph filtros = new Paragraph($"Filtros: Nombre: {nombre ?? "Todos"}, Categoría: {categoriaId}, Estado: {(estado ? "Activo" : "Inactivo")}, Orden: {ordenStock}");
                filtros.Alignment = Element.ALIGN_LEFT;
                filtros.Font.Size = 10;
                document.Add(filtros);

                document.Add(new Paragraph(" "));

                // Tabla de productos (ahora con 8 columnas incluyendo imagen)
                PdfPTable table = new PdfPTable(8);
                table.WidthPercentage = 100;
                table.SetWidths(new float[] { 2f, 2f, 1f, 1f, 1f, 1f, 1f, 1.5f }); // Ajuste de anchos

                // Encabezados
                table.AddCell("Nombre");
                table.AddCell("Descripción");
                table.AddCell("Precio");
                table.AddCell("Stock");
                table.AddCell("Imagen");
                table.AddCell("Categoría");
                table.AddCell("Estado");
                table.AddCell("Código");

                // Configuración para imágenes
                float maxImageHeight = 50f; // Altura máxima de la imagen en puntos (1 punto = 1/72 pulgadas)

                // Datos
                foreach (var producto in productos)
                {
                    // Nombre
                    table.AddCell(producto.nombre);

                    // Descripción
                    table.AddCell(producto.descripcion);

                    // Precio
                    table.AddCell(producto.precio.ToString("₡#,##0.00"));

                    // Stock
                    table.AddCell(producto.stock.ToString());

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
                            imageCell.AddElement(new Phrase("Imagen no disponible"));
                        }
                    }
                    else
                    {
                        imageCell.AddElement(new Phrase("Sin imagen"));
                    }

                    table.AddCell(imageCell);

                    // Categoría
                    table.AddCell(producto.Categoria_ID.ToString());

                    // Estado
                    table.AddCell(producto.Estado ? "Activo" : "Inactivo");

                    // Código
                    table.AddCell(producto.CodigoDelProducto.ToString());
                }

                document.Add(table);
                document.Close();

                return File(stream.ToArray(), "application/pdf", "Inventario.pdf");
            }
        }

        public ActionResult ExportarExcel(string nombre, int categoriaId = 0, bool estado = true, string ordenStock = "")
        {
            var productos = ObtenerProductosFiltrados(nombre, categoriaId, estado, ordenStock);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Inventario");

                // Título
                worksheet.Cell(1, 1).Value = "Reporte de Inventario";
                worksheet.Range(1, 1, 1, 7).Merge().Style.Font.Bold = true;

                // Filtros
                worksheet.Cell(2, 1).Value = $"Filtros: Nombre: {nombre ?? "Todos"}, Categoría: {categoriaId}, Estado: {(estado ? "Activo" : "Inactivo")}, Orden: {ordenStock}";
                worksheet.Range(2, 1, 2, 7).Merge();

                // Encabezados
                worksheet.Cell(4, 1).Value = "Nombre";
                worksheet.Cell(4, 2).Value = "Descripción";
                worksheet.Cell(4, 3).Value = "Precio";
                worksheet.Cell(4, 4).Value = "Stock";
                worksheet.Cell(4, 5).Value = "Categoría";
                worksheet.Cell(4, 6).Value = "Estado";
                worksheet.Cell(4, 7).Value = "Código";

                // Datos
                int row = 5;
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

            var sb = new StringBuilder();

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