using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TorresJ_Liga_Pro_de_Ecuador.Models
{
    public class Jugador
    {
        [Key]
        [Display(Name = "Nombre del Jugador")]
        [Required(ErrorMessage = "El nombre del jugador es obligatorio.")]
        public string IdNombre { get; set; }

        [Display(Name = "Dorsal")]
        [Range(1, 99, ErrorMessage = "El dorsal debe estar entre 1 y 99.")]
        public int dorsal { get; set; }

        [Display(Name = "Goles")]
        [Range(0, 100, ErrorMessage = "El número de goles debe estar entre 0 y 100.")]
        public int goles { get; set; }

        [Display(Name = "Asistencias")]
        [Range(0, 100, ErrorMessage = "El número de asistencias debe estar entre 0 y 100.")]
        public int asistencias { get; set; }

        [Display(Name = "Sueldo")]
        [DataType(DataType.Currency, ErrorMessage = "El sueldo debe ser un valor monetario.")]
        [Range(0, 1000000, ErrorMessage = "El sueldo debe estar entre 0 y 1,000,000.")]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal sueldo { get; set; }

        [Display(Name = "Equipo Actual")]
        [Required(ErrorMessage = "El equipo actual es obligatorio.")]
        public int IdEquipoActual { get; set; }

        [ForeignKey("IdEquipoActual")]
        public Equipo? Equipo { get; set; }
    }

}
