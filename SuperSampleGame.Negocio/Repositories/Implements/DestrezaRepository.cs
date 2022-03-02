using SuperSampleGame.Negocio.Data;
using SuperSampleGame.Negocio.Models;
using System.Data.Entity;
using System.Threading.Tasks;

namespace SuperSampleGame.Negocio.Repositories.Implements
{
    public class DestrezaRepository : GenericRepository<Destreza>, IDestrezaRepository
    {
        private readonly SuperSampleGameContext _superSampleGameContext;

        public DestrezaRepository(SuperSampleGameContext superSampleGameContext) : base(superSampleGameContext)
        {
            _superSampleGameContext = superSampleGameContext;
        }

        public async Task<bool> DeleteCheckOnEntity(int id)
        {
            var flag = await _superSampleGameContext.GuerrerosDestrezas.AnyAsync(x => x.DestrezaId == id);

            return flag;
        }
    }
}
