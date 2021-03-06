using SuperSampleGame.Negocio.Models;
using SuperSampleGame.Negocio.Repositories;
using SuperSampleGame.Negocio.Repositories.Implements;
using System;
using System.Threading.Tasks;

namespace SuperSampleGame.Negocio.Services.Implements
{
    public class CategoriaService : GenericService<Categoria>
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public CategoriaService(ICategoriaRepository categoriaRepository) : base(categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<bool> DeleteCheckOnEntity(int id)
        {
            return await _categoriaRepository.DeleteCheckOnEntity(id);
        }

        public Task<bool> DeleteOnCheckEntity(int id)
        {
            throw new NotImplementedException();
        }
    }
}
