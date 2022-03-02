using SuperSampleGame.Negocio.Data;
using SuperSampleGame.Negocio.Models;

namespace SuperSampleGame.Negocio.Repositories.Implements
{
    public class JugadorEquipamientoRepository : GenericRepository<JugadorEquipamiento>, IJugadorEquipamientoRepository
    {
        public JugadorEquipamientoRepository(SuperSampleGameContext superSampleGameContext) : base(superSampleGameContext)
        {

        }
    
    }
}
