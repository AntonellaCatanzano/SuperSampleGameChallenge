using SuperSampleGame.Negocio.Data;
using SuperSampleGame.Negocio.Models;

namespace SuperSampleGame.Negocio.Repositories.Implements
{
    public class GuerreroDestrezaRepository : GenericRepository<GuerreroDestreza>, IGuerreroDestrezaRepository
    {
        public GuerreroDestrezaRepository(SuperSampleGameContext superSampleGameContext) : base(superSampleGameContext)
        {

        }
    
    }
}
