using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    public class CajaController : Controller
    {
        // GET: CajasController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CajasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CajasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CajasController/Create
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

        // GET: CajasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CajasController/Edit/5
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

        // GET: CajasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CajasController/Delete/5
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
