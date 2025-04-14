using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TorresJ_Liga_Pro_de_Ecuador.Models
{
    public class Equipo
    {
        [Key]
        public int IdEquipo { get; set; }
        [Required]
        [MaxLength(100)]
        [DisplayName("Ingrese el nombre: ")]
        public string? NombreEquipo { get; set; }
        public string LogoUrl { get; set; }
        [MaxLength(100)]
        public string Descripcion { get; set; }
        [Range(0,20)]
        public int NumPartidosJugados { get; set; }
        [Range(0, 20)]
        public int NumPartidosGanados { get; set; }
        [Range(0, 20)]
        public int NumPartidosPerdidos { get; set; }
        [Range(0, 20)]
        public int NumPartidosEmpatados { get; set; }

        public int Puntos { get; set; }
    }
}
