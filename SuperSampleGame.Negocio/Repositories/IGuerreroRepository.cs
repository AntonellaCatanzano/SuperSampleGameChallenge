using SuperSampleGame.Negocio.Models;
using System.Threading.Tasks;

namespace SuperSampleGame.Negocio.Repositories.Implements
{
    public interface IGuerreroRepository : IGenericRepository<Guerrero>
    {
        Task<bool> DeleteCheckOnEntity(int id); 
    }
}
