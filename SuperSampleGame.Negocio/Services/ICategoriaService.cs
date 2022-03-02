using SuperSampleGame.Negocio.Models;
using System.Threading.Tasks;

namespace SuperSampleGame.Negocio.Services
{
    public interface ICategoriaService : IGenericService<Categoria>
    {
        Task<bool> DeleteCheckOnEntity(int id);
    }

}
