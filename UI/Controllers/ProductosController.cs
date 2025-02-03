using Abstracciones.LN.Interfaces.Categorias.ListarCategorias;
using Abstracciones.LN.Interfaces.Productos.CrearProducto;
using Abstracciones.LN.Interfaces.Productos.ListarProducto;
using Abstracciones.Modelos.Productos;
using LN.Categorias.ListarCategorias;
using LN.Productos.CrearProducto;
using LN.Productos.ListarProductos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class ProductosController : Controller
    {
        ICrearProductoLN _crearProducto;
        IListarProductoLN _listarProducto;
        IListarCategoriasLN _listarCategorias;
        public ProductosController() 
        {
            _crearProducto = new CrearProductoLN();
            _listarProducto = new ListarProductoLN();
            _listarCategorias = new ListarCategoriasLN();
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Productos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
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
    }
}
