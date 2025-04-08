using TorresJ_Liga_Pro_de_Ecuador.Models;

namespace TorresJ_Liga_Pro_de_Ecuador.Repos
{
    public class EquipoRepo
    {
        public IEnumerable<Equipo> DevuelveListadoEquipos() 
        {
            List<Equipo> equipos = new List<Equipo>();
            Equipo LDU = new Equipo
            {
                IdEquipo = 1,
                NombreEquipo = "Liga Deportiva Universitaria",
                NumPartidosEmpatados = 0,
                NumPartidosGanados = 10,
                NumPartidosJugados = 10,
                NumPartidosPerdidos = 0,
                Puntos = 30
            };
            equipos.Add(LDU);
            Equipo BSC = new Equipo
            {
                IdEquipo = 1,
                NombreEquipo = "Barcelona Sporting Club",
                NumPartidosEmpatados = 0,
                NumPartidosGanados = 10,
                NumPartidosJugados = 10,
                NumPartidosPerdidos = 0,
                Puntos = 30
            };
            equipos.Add(BSC);
            return equipos;
        }
    }
}
