using SuperSampleGame.Negocio.Models;
using System.Threading.Tasks;

namespace SuperSampleGame.Negocio.Services
{
    public interface IJugadorService : IGenericService<Jugador>
    {
        Task<bool> DeleteCheckOnEntity(int id);
    }
}
