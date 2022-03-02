using SuperSampleGame.Negocio.Data;
using SuperSampleGame.Negocio.Models;
using System.Data.Entity;
using System.Threading.Tasks;

namespace SuperSampleGame.Negocio.Repositories.Implements
{
    public class CategoriaRepository : GenericRepository<Categoria>, ICategoriaRepository
    {
        private readonly SuperSampleGameContext _superSampleGameContext;

        public CategoriaRepository(SuperSampleGameContext superSampleGameContext) : base(superSampleGameContext)
        {
            _superSampleGameContext = superSampleGameContext;
        }
        public async Task<bool> DeleteCheckOnEntity(int id)
        {
            var flag = await _superSampleGameContext.Equipamiento.AnyAsync(x => x.CategoriaId == id);

            return flag;
        }
        
    }
    
}
