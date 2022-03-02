using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperSampleGame.Negocio.Models
{
    [Table("Niveles", Schema = "dbo")]
    public class Nivel
    {
        [Key]
        public int IdNivel { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo Grado es Requerido")]
        [Range(1, 10)]
        public int Grado { get; set; }

        public virtual ICollection<Jugador> Jugadores { get; set; }

       
    }
}
