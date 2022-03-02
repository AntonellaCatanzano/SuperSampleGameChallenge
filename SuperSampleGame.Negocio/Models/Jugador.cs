using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SuperSampleGame.Negocio.Models
{
    [Table("Jugadores", Schema = "dbo")]
	public class Jugador
	{
		[Key]
		public int IdJugador { get; set; }

		[Required]
		public string Nombre { get; set; }
		public int Reintentos { get; set; }
		[Required]
		public int Oro { get; set; }
		[Required]
		public int Diamantes { get; set; }

		[ForeignKey("Nivel")]
		[Required]
		public int NivelId { get; set; }

		public Nivel Nivel { get; set; }

		public virtual ICollection<JugadorEquipamiento> JugadorEquipamientos { get; set; }

	}
}
