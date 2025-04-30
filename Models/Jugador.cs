using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TorresJ_Liga_Pro_de_Ecuador.Models
{
    public class Jugador
    {
        [Key]
        public string IdNombre { get; set; }
        public int dorsal { get; set; }
        public int goles { get; set; }
        public int asistencias { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal sueldo { get; set; }
        public int IdEquipoActual { get; set; }
        [ForeignKey("IdEquipoActual")]
        public Equipo? Equipo { get; set; }
        
    }
}
