using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TorresJ_Liga_Pro_de_Ecuador.Models;
using TorresJ_Liga_Pro_de_Ecuador.Repos;

namespace TorresJ_Liga_Pro_de_Ecuador.Controllers
{
    public class EquipoController : Controller
    {
        // GET: EquipoController
        public ActionResult List()
        {
            EquipoRepo repo = new EquipoRepo();
            var equipos = repo.DevuelveListadoEquipos();

            return View(equipos);
        }

        // GET: EquipoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EquipoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EquipoController/Create
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

        // GET: EquipoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EquipoController/Edit/5
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

        // GET: EquipoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EquipoController/Delete/5
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
