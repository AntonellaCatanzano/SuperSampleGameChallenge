using SuperSampleGame.Negocio.Models;
using System.Threading.Tasks;

namespace SuperSampleGame.Negocio.Repositories
{
    public interface ICategoriaRepository : IGenericRepository<Categoria>
    {
        Task<bool> DeleteCheckOnEntity(int id);
    }
}

