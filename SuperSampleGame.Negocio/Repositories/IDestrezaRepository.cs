using SuperSampleGame.Negocio.Models;
using System.Threading.Tasks;

namespace SuperSampleGame.Negocio.Repositories
{
    public interface IDestrezaRepository : IGenericRepository<Destreza>
    {
        Task<bool> DeleteCheckOnEntity(int id);
    }
}
