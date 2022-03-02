using SuperSampleGame.Negocio.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperSampleGame.Negocio.Services.Implements
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class
    {
        private IGenericRepository<TEntity> _genericRepository;

        public GenericService(IGenericRepository<TEntity> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task Delete(int id)
        {
            await _genericRepository.Delete(id);
        }

        public Task<bool> DeleteCheckOnEntity(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _genericRepository.GetAll();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _genericRepository.GetById(id);
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            return await _genericRepository.Insert(entity);
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            return await _genericRepository.Update(entity);
        }
    }
}
