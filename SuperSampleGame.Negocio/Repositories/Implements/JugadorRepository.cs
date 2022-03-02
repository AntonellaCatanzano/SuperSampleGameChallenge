using SuperSampleGame.Negocio.Data;
using SuperSampleGame.Negocio.Models;
using System.Data.Entity;
using System.Threading.Tasks;

namespace SuperSampleGame.Negocio.Repositories.Implements
{
    public class JugadorRepository : GenericRepository<Jugador>, IJugadorRepository
    {
        private readonly SuperSampleGameContext _superSampleGameContext;

        public JugadorRepository(SuperSampleGameContext superSampleGameContext) : base(superSampleGameContext)
        {
            _superSampleGameContext = superSampleGameContext;
        }

        public async Task<bool> DeleteCheckOnEntity(int id)
        {
            var flag = await _superSampleGameContext.GuerrerosDestrezas.AnyAsync(x => x.NivelId == id);

            return flag;
        }

    }
}
