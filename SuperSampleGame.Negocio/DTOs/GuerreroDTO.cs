using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SuperSampleGame.Negocio.DTOs
{
    public class GuerreroDTO
    {   
        [Required]
        public int IdGuerrero { get; set; }

        [Required(ErrorMessage = "El campo Nombre es requerido")]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Tipo es requerido")]
        public string Tipo { get; set; }
        
        public int Vida { get; set; }

        public int HabilidadOfensiva { get; set; }

        public int HabilidadDefensiva { get; set; }

        
    }
}
