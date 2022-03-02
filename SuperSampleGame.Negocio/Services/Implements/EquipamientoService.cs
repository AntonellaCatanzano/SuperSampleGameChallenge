using SuperSampleGame.Negocio.Models;
using SuperSampleGame.Negocio.Repositories;
using System;
using System.Threading.Tasks;

namespace SuperSampleGame.Negocio.Services.Implements
{
    public class EquipamientoService : GenericService<Equipamiento>, IEquipamientoService
    {
        private readonly IEquipamientoRepository _equipamientoRepository;
        public EquipamientoService(IEquipamientoRepository equipamientoRepository) : base(equipamientoRepository)
        {
            _equipamientoRepository = equipamientoRepository;
        }
        public async Task<bool> DeleteCheckOnEntity(int id)
        {
            return await _equipamientoRepository.DeleteCheckOnEntity(id);
        }

        public Task<bool> DeleteOnCheckEntity(int id)
        {
            throw new NotImplementedException();
        }
    }
}
