using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    public class ListaOrdenesController : Controller
    {
        // GET: ListaOrdenesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ListaOrdenesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ListaOrdenesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ListaOrdenesController/Create
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

        // GET: ListaOrdenesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ListaOrdenesController/Edit/5
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

        // GET: ListaOrdenesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ListaOrdenesController/Delete/5
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
