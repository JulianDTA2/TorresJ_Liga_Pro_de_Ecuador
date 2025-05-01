namespace TorresJ_Liga_Pro_de_Ecuador.ViewModels
{
    public class ReporteViewModel
    {
        public List<JugadorReporte> TopGoleadores { get; set; }
        public List<JugadorReporte> TopAsistentes { get; set; }
        public List<EquipoReporte> TopEquiposPorPresupuesto { get; set; }
    }

    public class JugadorReporte
    {
        public string Nombre { get; set; }
        public int Valor { get; set; } // Goles o Asistencias
    }

    public class EquipoReporte
    {
        public string NombreEquipo { get; set; }
        public decimal Presupuesto { get; set; }
    }
}
