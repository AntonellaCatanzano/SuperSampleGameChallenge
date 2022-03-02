using SuperSampleGame.Negocio.Models;
using System.Threading.Tasks;

namespace SuperSampleGame.Negocio.Repositories
{
    public interface INivelRepository : IGenericRepository<Nivel>
    {
        Task<bool> DeleteCheckOnEntity(int id);
    }
}
