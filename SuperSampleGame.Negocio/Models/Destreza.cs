using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperSampleGame.Negocio.Models
{
    [Table("Destrezas", Schema = "dbo")]
    public class Destreza
    {
        [Key]
        public int IdDestreza { get; set; }

        [Required]
        public string Descripcion { get; set; }

        public virtual ICollection<GuerreroDestreza> GuerrerosDestrezas { get; set; }
    }
}
