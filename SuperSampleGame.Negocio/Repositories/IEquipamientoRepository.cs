using SuperSampleGame.Negocio.Models;
using System.Threading.Tasks;

namespace SuperSampleGame.Negocio.Repositories
{
    public interface IEquipamientoRepository : IGenericRepository<Equipamiento>
    {
        Task<bool> DeleteCheckOnEntity(int id);
    }
}
