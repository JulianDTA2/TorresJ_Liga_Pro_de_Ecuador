using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TorresJ_Liga_Pro_de_Ecuador.Models;
using TorresJ_Liga_Pro_de_Ecuador.Data;

namespace TorresJ_Liga_Pro_de_Ecuador.Controllers
{
    public class JugadoresController : Controller
    {
        private readonly TorresJ_Liga_Pro_de_EcuadorContext _context;

        public JugadoresController(TorresJ_Liga_Pro_de_EcuadorContext context)
        {
            _context = context;
        }

        // GET: Jugadores
        public async Task<IActionResult> Index()
        {
            var torresJ_Liga_Pro_de_EcuadorContext = _context.Jugador.Include(j => j.Equipo);
            return View(await torresJ_Liga_Pro_de_EcuadorContext.ToListAsync());
        }

        // GET: Jugadores/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jugador = await _context.Jugador
                .Include(j => j.Equipo)
                .FirstOrDefaultAsync(m => m.IdNombre == id);
            if (jugador == null)
            {
                return NotFound();
            }

            return View(jugador);
        }

        // GET: Jugadores/Create
        public IActionResult Create()
        {
            ViewData["IdEquipoActual"] = new SelectList(_context.Set<Equipo>(), "IdEquipo", "NombreEquipo");
            return View();
        }

        // POST: Jugadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNombre,dorsal,goles,asistencias,sueldo,IdEquipoActual")] Jugador jugador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jugador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEquipoActual"] = new SelectList(_context.Set<Equipo>(), "IdEquipo", "NombreEquipo", jugador.IdEquipoActual);
            return View(jugador);
        }

        // GET: Jugadores/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jugador = await _context.Jugador.FindAsync(id);
            if (jugador == null)
            {
                return NotFound();
            }
            ViewData["IdEquipoActual"] = new SelectList(_context.Set<Equipo>(), "IdEquipo", "NombreEquipo", jugador.IdEquipoActual);
            return View(jugador);
        }

        // POST: Jugadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdNombre,dorsal,goles,asistencias,sueldo,IdEquipoActual")] Jugador jugador)
        {
            if (id != jugador.IdNombre)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jugador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JugadorExists(jugador.IdNombre))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEquipoActual"] = new SelectList(_context.Set<Equipo>(), "IdEquipo", "NombreEquipo", jugador.IdEquipoActual);
            return View(jugador);
        }

        // GET: Jugadores/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jugador = await _context.Jugador
                .Include(j => j.Equipo)
                .FirstOrDefaultAsync(m => m.IdNombre == id);
            if (jugador == null)
            {
                return NotFound();
            }

            return View(jugador);
        }

        // POST: Jugadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var jugador = await _context.Jugador.FindAsync(id);
            if (jugador != null)
            {
                _context.Jugador.Remove(jugador);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JugadorExists(string id)
        {
            return _context.Jugador.Any(e => e.IdNombre == id);
        }
    }
}
