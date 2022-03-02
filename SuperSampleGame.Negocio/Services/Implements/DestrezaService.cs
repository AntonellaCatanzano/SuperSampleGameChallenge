using SuperSampleGame.Negocio.Models;
using SuperSampleGame.Negocio.Repositories;
using SuperSampleGame.Negocio.Repositories.Implements;
using System;
using System.Threading.Tasks;

namespace SuperSampleGame.Negocio.Services.Implements
{
    public class DestrezaService : GenericService<Destreza>
    {
        private readonly IDestrezaRepository _destrezaRepository;
        public DestrezaService(IDestrezaRepository destrezaRepository) : base(destrezaRepository)
        {
            _destrezaRepository = destrezaRepository;
        }
        public async Task<bool> DeleteCheckOnEntity(int id)
        {
            return await _destrezaRepository.DeleteCheckOnEntity(id);
        }

        public Task<bool> DeleteOnCheckEntity(int id)
        {
            throw new NotImplementedException();
        }
    }
}
