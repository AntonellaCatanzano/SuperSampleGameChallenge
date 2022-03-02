using SuperSampleGame.Negocio.Models;
using SuperSampleGame.Negocio.Repositories.Implements;
using System;
using System.Threading.Tasks;

namespace SuperSampleGame.Negocio.Services.Implements
{
    public class GuerreroService : GenericService<Guerrero>, IGuerreroService
    {
        private readonly IGuerreroRepository _guerreroRepository;
        public GuerreroService(IGuerreroRepository guerreroRepository) : base(guerreroRepository)
        {
            _guerreroRepository = guerreroRepository;
        }

        public async Task<bool> DeleteCheckOnEntity(int id)
        {
            return await _guerreroRepository.DeleteCheckOnEntity(id);
        }

        public Task<bool> DeleteOnCheckEntity(int id)
        {
            throw new NotImplementedException();
        }
    }
}
