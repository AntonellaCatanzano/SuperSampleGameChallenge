using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperSampleGame.Negocio.Models
{
    [Table("JugadoresEquipamiento", Schema = "dbo")]
    public class JugadorEquipamiento
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Equipamiento")]
        [Required]
        public int EquipamientoId { get; set; }

        [ForeignKey("Jugador")]
        [Required]
        public int JugadorId { get; set; }

        [ForeignKey("Guerrero")]
        [Required]
        public int GuerreroId { get; set; }

        public Equipamiento Equipamiento { get; set; }

        public Jugador Jugador { get; set; }

        public Guerrero Guerrero { get; set; }
    }
}
