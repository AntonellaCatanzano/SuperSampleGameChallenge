using SuperSampleGame.Negocio.Models;
using SuperSampleGame.Negocio.Repositories.Implements;

namespace SuperSampleGame.Negocio.Services.Implements
{
    class JugadorEquipamientoService : GenericService<JugadorEquipamiento>, IJugadorEquipamientoService
    {
        public JugadorEquipamientoService(JugadorEquipamientoRepository jugadorEquipamientoRepository) : base(jugadorEquipamientoRepository)
        {

        }
    
    }
}
