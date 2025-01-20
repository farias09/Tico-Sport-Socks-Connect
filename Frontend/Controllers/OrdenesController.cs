using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    public class OrdenesController : Controller
    {
        // GET: OrdenesController
        public ActionResult Index()
        {
            return View();
        }
        public IActionResult DetallesChat()
        {
            return View();
        }

        public IActionResult VentaFisica()
        {
            return View();
        }

        public IActionResult DetalleProducto()
        {
            return View();
        }

        public IActionResult OrdenesPendientes()
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
