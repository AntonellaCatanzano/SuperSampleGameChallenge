using SuperSampleGame.Negocio.Models;
using System.Threading.Tasks;

namespace SuperSampleGame.Negocio.Services
{
    public interface INivelService : IGenericService<Nivel>
    {
        Task<bool> DeleteCheckOnEntity(int id);
    }
}
