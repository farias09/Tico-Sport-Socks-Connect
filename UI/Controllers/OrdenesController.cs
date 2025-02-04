using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin;

namespace UI.Controllers
{
    public class OrdenesController : Controller
    {
        // GET: OrdenesController
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DetallesChat()
        {
            return View();
        }

        public ActionResult VentaFisica()
        {
            return View();
        }

        public ActionResult DetalleProducto()
        {
            return View();
        }

        public ActionResult OrdenesPendientes()
        {
            return View();
        }

        // GET: OrdenesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrdenesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrdenesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrdenesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrdenesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrdenesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrdenesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
