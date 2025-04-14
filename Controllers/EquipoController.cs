using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TorresJ_Liga_Pro_de_Ecuador.Models;
using TorresJ_Liga_Pro_de_Ecuador.Repos;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TorresJ_Liga_Pro_de_Ecuador.Controllers
{
    public class EquipoController : Controller
    {
        public ActionResult Tabla()
        {
            EquipoRepo repo = new EquipoRepo();
            var equipos = repo.DevuelveListadoEquipos();
            return View(equipos);

        }

        [HttpPost]
        public IActionResult ActualizarEquipo(Equipo equipo)
        {
            EquipoRepo repo = new EquipoRepo();
            var equipos = repo.DevuelveListadoEquipos();
            if (eq != null)
            {
                equipos.Ganados = equipo.NumPartidosGanados;
                equipos.Empatados = equipo.NumPartidosEmpatados;
                equipos.Perdidos = equipo.NumPartidosPerdidos;
                equipos.Jugados = equipo.NumPartidosGanados + equipo.NumPartidosEmpatados + equipo.NumPartidosPerdidos;
            }
            return RedirectToAction("Tabla");
        }

        public IActionResult Detalle(int id)
        {
            var equipo = EquipoRepo.Equipos.FirstOrDefault(e => e.Id == id);
            return View(equipo);
        }
    } 
}
