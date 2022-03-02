using SuperSampleGame.Negocio.Models;
using System.Threading.Tasks;

namespace SuperSampleGame.Negocio.Services
{
    public interface IGuerreroService : IGenericService<Guerrero>
    {
        Task<bool> DeleteCheckOnEntity(int id);
    }
}
