// Repos/EquipoRepo.cs
using Microsoft.EntityFrameworkCore;
using TorresJ_Liga_Pro_de_Ecuador.Data;
using TorresJ_Liga_Pro_de_Ecuador.Models;

namespace TorresJ_Liga_Pro_de_Ecuador.Repos
{
    public class EquipoRepo
    {
        private readonly TorresJ_Liga_Pro_de_EcuadorContext _context;

        public EquipoRepo(TorresJ_Liga_Pro_de_EcuadorContext context)
        {
            _context = context;

   
        }

        public void Agregar(Equipo equipo)
        {
            equipo.Puntos = equipo.NumPartidosGanados * 3 + equipo.NumPartidosEmpatados;
            _context.Equipo.Add(equipo);
            _context.SaveChanges();
        }

        public List<Equipo> ObtenerTodos()
        {
            return _context.Equipo.OrderByDescending(e => e.Puntos).ToList();
        }

        public Equipo? ObtenerPorNombre(string nombre)
        {
            return _context.Equipo.FirstOrDefault(e => e.NombreEquipo == nombre);
        }

        public void ActualizarEstadisticas(string nombre, int ganados, int empatados, int perdidos)
        {
            var equipo = ObtenerPorNombre(nombre);
            if (equipo != null)
            {
                equipo.NumPartidosGanados = ganados;
                equipo.NumPartidosEmpatados = empatados;
                equipo.NumPartidosPerdidos = perdidos;
                equipo.NumPartidosJugados = ganados + empatados + perdidos;
                equipo.Puntos = (ganados * 3) + empatados;
                _context.SaveChanges();
            }
        }
    }
}
