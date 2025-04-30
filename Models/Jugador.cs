using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TorresJ_Liga_Pro_de_Ecuador.Models
{
    public class Jugador
    {
        [Key]
        [Display(Name = "Nombre del Jugador")]
        public string IdNombre { get; set; }
        [Required]
        [Range(0,99)]
        [Display(Name = "Dorsal")]
        public int dorsal { get; set; }
        [Display(Name = "Goles")]
        [Range(0, 99)]
        public int goles { get; set; }
        [Range(0, 99)]
        [Display(Name = "Asistencias")]
        public int asistencias { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        [Display(Name = "Sueldo")]
        public decimal sueldo { get; set; }
        [Display(Name = "Equipo actual")]
        public int IdEquipoActual { get; set; }
        [ForeignKey("IdEquipoActual")]
        public Equipo? Equipo { get; set; }
        
    }
}
