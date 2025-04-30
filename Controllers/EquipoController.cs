// Controllers/EquipoController.cs
using Microsoft.AspNetCore.Mvc;
using TorresJ_Liga_Pro_de_Ecuador.Models;
using TorresJ_Liga_Pro_de_Ecuador.Repos;

namespace TorresJ_Liga_Pro_de_Ecuador.Controllers
{
    public class EquipoController : Controller
    {
        private readonly EquipoRepo _repo;

        public EquipoController(EquipoRepo repo)
        {
            _repo = repo;
        }

        public IActionResult Tabla()
        {
            var equipos = _repo.ObtenerTodos();
            return View(equipos);
        }

        public IActionResult Detalle(string nombre)
        {
            var equipo = _repo.ObtenerPorNombre(nombre);
            if (equipo == null) return NotFound();
            return View(equipo);
        }

        [HttpPost]
        public IActionResult GuardarEstadisticas(string nombre, int ganados, int empatados, int perdidos)
        {
            _repo.ActualizarEstadisticas(nombre, ganados, empatados, perdidos);
            return RedirectToAction("Tabla");
        }

        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(Equipo nuevoEquipo)
        {
            if (ModelState.IsValid)
            {
                _repo.Agregar(nuevoEquipo);
                return RedirectToAction("Tabla");
            }
            return View(nuevoEquipo);
        }
    }
}
