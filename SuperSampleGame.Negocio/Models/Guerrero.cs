using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperSampleGame.Negocio.Models
{
    [Table("Guerreros", Schema = "dbo")]
    public class Guerrero
    {
        [Key]
        public int IdGuerrero { get; set; }
        
        public string Nombre { get; set; }
        
        public string Tipo { get; set; }
        
        public int Vida { get; set; }

        public int HabilidadOfensiva { get; set; }

        public int HabilidadDefensiva { get; set; }

        public virtual ICollection<GuerreroDestreza> GuerreroDestrezas { get; set; }

       
    }
}
