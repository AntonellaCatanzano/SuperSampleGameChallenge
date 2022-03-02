using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSampleGame.Negocio.DTOs
{
    public class GuerreroDestrezaDTO
    {       

        [Required]
        public int GuerreroId { get; set; }

        [Required]
        public int DestrezaId { get; set; }

        [Required]
        public int NivelId { get; set; }

        public GuerreroDTO Guerrero { get; set; }

        public DestrezaDTO Destreza { get; set; }

        public NivelDTO Nivel { get; set; }
    }
}
