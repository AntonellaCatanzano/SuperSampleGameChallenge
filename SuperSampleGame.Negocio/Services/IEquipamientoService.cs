using SuperSampleGame.Negocio.Models;
using System.Threading.Tasks;

namespace SuperSampleGame.Negocio.Services
{
    public interface IEquipamientoService : IGenericService<Equipamiento>
    {
        Task<bool> DeleteCheckOnEntity(int id);
    }
}
