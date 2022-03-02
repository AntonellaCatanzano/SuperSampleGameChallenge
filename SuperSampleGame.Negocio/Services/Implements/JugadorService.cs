using SuperSampleGame.Negocio.Models;
using SuperSampleGame.Negocio.Repositories;
using SuperSampleGame.Negocio.Repositories.Implements;
using System;
using System.Threading.Tasks;

namespace SuperSampleGame.Negocio.Services.Implements
{
    public class JugadorService : GenericService<Jugador>, IJugadorService
    {
        private readonly IJugadorRepository _jugadorRepository;
        public JugadorService(JugadorRepository jugadorRepository) : base(jugadorRepository)
        {
            _jugadorRepository = jugadorRepository;
        }

        public async Task<bool> DeleteCheckOnEntity(int id)
        {
            return await _jugadorRepository.DeleteCheckOnEntity(id);
        }

        public Task<bool> DeleteOnCheckEntity(int id)
        {
            throw new NotImplementedException();
        }
    }
}
