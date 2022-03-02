using SuperSampleGame.Negocio.Models;
using SuperSampleGame.Negocio.Repositories;

namespace SuperSampleGame.Negocio.Services.Implements
{
    public class GuerreroDestrezaService : GenericService<GuerreroDestreza>, IGuerreroDestrezaService
    {
        public GuerreroDestrezaService(IGuerreroDestrezaRepository guerreroDestrezaRepository) : base(guerreroDestrezaRepository)
        {

        }
    
    }
}
