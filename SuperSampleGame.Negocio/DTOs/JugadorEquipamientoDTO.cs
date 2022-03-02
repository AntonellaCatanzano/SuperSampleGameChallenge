using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSampleGame.Negocio.DTOs
{
    public class JugadorEquipamientoDTO
    {          
        [Required]
        public int JugadorId { get; set; }
       
        [Required]
        public int GuerreroId { get; set; }

    }
}
