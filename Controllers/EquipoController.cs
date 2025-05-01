// Controllers/EquipoController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TorresJ_Liga_Pro_de_Ecuador.Models;
using TorresJ_Liga_Pro_de_Ecuador.Repos;
using TorresJ_Liga_Pro_de_Ecuador.ViewModels;

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

            // Obtener jugadores del equipo
            var jugadores = _repo.ObtenerJugadoresPorEquipo(equipo.IdEquipo);

            // Crear un ViewModel para pasar ambos datos
            var viewModel = new EquipoDetalleViewModel
            {
                Equipo = equipo,
                Jugadores = jugadores
            };

            return View(viewModel);
        }

        public class EquipoDetalleViewModel
        {
            public Equipo Equipo { get; set; }
            public List<Jugador> Jugadores { get; set; }
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


        public IActionResult Reporte()
        {
            // Obtener los 5 jugadores con más goles
            var topGoleadores = _repo.ObtenerTodosLosJugadores()
                .OrderByDescending(j => j.goles)
                .Take(5)
                .Select(j => new JugadorReporte
                {
                    Nombre = j.IdNombre,
                    Valor = j.goles
                })
                .ToList();

            // Obtener los 5 jugadores con más asistencias
            var topAsistentes = _repo.ObtenerTodosLosJugadores()
                .OrderByDescending(j => j.asistencias)
                .Take(5)
                .Select(j => new JugadorReporte
                {
                    Nombre = j.IdNombre,
                    Valor = j.asistencias
                })
                .ToList();

            // Obtener los 5 equipos con mayor presupuesto
            var topEquiposPorPresupuesto = _repo.ObtenerTodos()
                .Select(e => new EquipoReporte
                {
                    NombreEquipo = e.NombreEquipo,
                    Presupuesto = _repo.ObtenerJugadoresPorEquipo(e.IdEquipo).Sum(j => j.sueldo)
                })
                .OrderByDescending(e => e.Presupuesto)
                .Take(5)
                .ToList();

            // Crear el ViewModel
            var viewModel = new ReporteViewModel
            {
                TopGoleadores = topGoleadores,
                TopAsistentes = topAsistentes,
                TopEquiposPorPresupuesto = topEquiposPorPresupuesto
            };

            return View(viewModel);
        }


    }
}
