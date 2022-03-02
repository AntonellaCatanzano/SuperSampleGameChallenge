using SuperSampleGame.Negocio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSampleGame.Negocio.DTOs
{   

    public class EquipamientoDTO
    {
        public int IdEquipamiento { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public int Costo { get; set; }

        [Required]
        public string Medida { get; set; }
        
        [Required]
        public int CategoriaId { get; set; }
        
    }
}
