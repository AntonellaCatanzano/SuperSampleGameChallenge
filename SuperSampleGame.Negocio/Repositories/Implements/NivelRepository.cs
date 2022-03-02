using SuperSampleGame.Negocio.Data;
using SuperSampleGame.Negocio.Models;
using System.Data.Entity;
using System.Threading.Tasks;

namespace SuperSampleGame.Negocio.Repositories.Implements
{
    public class NivelRepository : GenericRepository<Nivel>, INivelRepository
    {
        private readonly SuperSampleGameContext _superSampleGameContext;

        public NivelRepository(SuperSampleGameContext superSampleGameContext) : base(superSampleGameContext)
        {
            _superSampleGameContext = superSampleGameContext;
        }

        public async Task<bool> DeleteCheckOnEntity(int id)
        {
            var flag = await _superSampleGameContext.JugadoresEquipamiento.AnyAsync(x => x.JugadorId == id);

            return flag;
        }

    }
}
