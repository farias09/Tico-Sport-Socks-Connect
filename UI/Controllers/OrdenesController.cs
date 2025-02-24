﻿using System;
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
                // Deserializar los productos seleccionados
                var detalles = JsonConvert.DeserializeObject<List<DetalleOrdenesDto>>(ProductosSeleccionadosJson);

                // Crear la orden y obtener la instancia creada con su ID
                var ordenCreada = _ordenService.CrearOrden(orden, detalles);

                // Verificar si la orden fue creada exitosamente
                if (ordenCreada == null || ordenCreada.Orden_ID == 0)
                {
                    ModelState.AddModelError("", "Hubo un error al crear la orden.");
                    return View(orden);
                }

                // Redirigir a la vista de confirmación con los detalles de la orden creada
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

    }
}
