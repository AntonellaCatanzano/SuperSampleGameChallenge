using SuperSampleGame.Negocio.Models;
using System.Threading.Tasks;

namespace SuperSampleGame.Negocio.Repositories
{
    public interface IJugadorRepository : IGenericRepository<Jugador>
    {
        Task<bool> DeleteCheckOnEntity(int id);
    }
}
