using TorresJ_Liga_Pro_de_Ecuador.Models;

namespace TorresJ_Liga_Pro_de_Ecuador.Repos
{
    public class EquipoRepo
    {
        private static List<Equipo> equipos = new List<Equipo>
        {
            new Equipo {
                IdEquipo = 1,
                NombreEquipo = "Liga Deportiva Universitaria",
                LogoUrl = "/images/LDU.png",
                Descripcion = "El rey de copas de Ecuador.",
                NumPartidosJugados = 0,
                NumPartidosGanados = 0,
                NumPartidosPerdidos = 0,
                NumPartidosEmpatados = 0,
                Puntos = 0
            },
            new Equipo {
                IdEquipo = 2,
                NombreEquipo = "Barcelona SC",
                LogoUrl = "/images/barcelona.png",
                Descripcion = "Uno de los equipos más populares de Ecuador.",
                NumPartidosJugados = 0,
                NumPartidosGanados = 0,
                NumPartidosPerdidos = 0,
                NumPartidosEmpatados = 0,
                Puntos = 0
            },
            new Equipo {
                IdEquipo = 3,
                NombreEquipo = "Emelec",
                LogoUrl = "/images/emelec.png",
                Descripcion = "Equipo tradicional de Guayaquil.",
                NumPartidosJugados = 0,
                NumPartidosGanados = 0,
                NumPartidosPerdidos = 0,
                NumPartidosEmpatados = 0,
                Puntos = 0
            }
        };

        public void Agregar(Equipo equipo)
        {
            equipo.IdEquipo = equipos.Count + 1;
            equipo.Puntos = equipo.NumPartidosGanados * 3 + equipo.NumPartidosEmpatados;
            equipos.Add(equipo);
        }

        public List<Equipo> ObtenerTodos()
        {
            return equipos.OrderByDescending(e => e.Puntos).ToList();
        }

        public Equipo? ObtenerPorNombre(string nombre)
        {
            return equipos.FirstOrDefault(e => e.NombreEquipo == nombre);
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
            }
        }
    }
}
