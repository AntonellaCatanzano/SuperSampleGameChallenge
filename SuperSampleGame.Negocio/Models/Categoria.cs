using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperSampleGame.Negocio.Models
{
    public enum Medida
    {
        Oros, Diamantes
    }

    [Table("Categorias", Schema = "dbo")]
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }

        [Required]
        public string Descripcion { get; set; }

       public virtual ICollection<Equipamiento> Equipamientos { get; set; }
    }
}
