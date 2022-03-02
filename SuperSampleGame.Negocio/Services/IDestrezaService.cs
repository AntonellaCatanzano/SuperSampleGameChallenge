using SuperSampleGame.Negocio.Models;
using System.Threading.Tasks;

namespace SuperSampleGame.Negocio.Services
{
    public interface IDestrezaService : IGenericService<Destreza>
    {
        Task<bool> DeleteCheckOnEntity(int id);
    }
}
