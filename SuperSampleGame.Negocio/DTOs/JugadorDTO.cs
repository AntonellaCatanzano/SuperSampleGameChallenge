using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSampleGame.Negocio.DTOs
{
    public class JugadorDTO
    {
        public int IdJugador { get; set; }
        [Required]
        public string Nombre { get; set; }

        public int Reintentos { get; set; }

        [Required]
        public int Oro { get; set; }

        [Required]
        public int Diamantes { get; set; }

        [Required]
        public int NivelId { get; set; }
    }
}
