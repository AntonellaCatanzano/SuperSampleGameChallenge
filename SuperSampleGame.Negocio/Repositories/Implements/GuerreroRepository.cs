using SuperSampleGame.Negocio.Data;
using SuperSampleGame.Negocio.Models;
using System.Data.Entity;
using System.Threading.Tasks;

namespace SuperSampleGame.Negocio.Repositories.Implements
{
    public class GuerreroRepository : GenericRepository<Guerrero>, IGuerreroRepository
    {

        private readonly SuperSampleGameContext _superSampleGameContext;
        public GuerreroRepository(SuperSampleGameContext superSampleGameContext) : base(superSampleGameContext)
        {
            _superSampleGameContext = superSampleGameContext;
        }

        public async Task<bool> DeleteCheckOnEntity(int id)
        {
            var flag = await _superSampleGameContext.GuerrerosDestrezas.AnyAsync(x => x.GuerreroId == id);

            return flag;
        }
    }
}
