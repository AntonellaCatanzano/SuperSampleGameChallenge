using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSampleGame.Negocio.DTOs
{
    public class NivelDTO
    {
        public int IdNivel { get; set; }

        [Required(ErrorMessage = "El campo Descripción es Requerido")]
        public string Descripcion { get; set; }

        
        [Required(ErrorMessage = "El campo Grado es Requerido")]
        [Range(1, 10)]
        public int Grado { get; set; }
    }
}
