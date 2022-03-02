using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperSampleGame.Negocio.Models
{
    [Table("GuerrerosDestrezas", Schema = "dbo")]
    public class GuerreroDestreza
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Guerrero")]
        public int GuerreroId { get; set; }

        [ForeignKey("Destreza")]
        public int DestrezaId { get; set; }

        [ForeignKey("Nivel")]
        public int NivelId { get; set; }

        public Guerrero Guerrero { get; set; }

        public Destreza Destreza { get; set; }

        public Nivel Nivel { get; set; }
    }
}
