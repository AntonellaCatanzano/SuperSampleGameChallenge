using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperSampleGame.Negocio.Models
{    

    [Table("Equipamiento", Schema = "dbo")]
    public class Equipamiento
    {
        [Key]
        public int IdEquipamiento { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public int Costo { get; set; }

        [Required]
        public string Medida { get; set; }

        [ForeignKey("Categoria")]
        [Required]
        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }

        public virtual ICollection<JugadorEquipamiento> JugadorEquipamientos { get; set; }

    }
}
