using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSampleGame.Negocio.DTOs
{
    public class DestrezaDTO
    {
        
        public int IdDestreza { get; set; }

        [Required]
        [StringLength(100)]
        public string Descripcion { get; set; }
    }
}
