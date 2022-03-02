using SuperSampleGame.Negocio.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace SuperSampleGame.Negocio.Repositories.Implements
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly SuperSampleGameContext _superSampleGameContext;

        public GenericRepository(SuperSampleGameContext superSampleGameContext)
        {
           _superSampleGameContext = superSampleGameContext;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);

            if (entity == null) throw new Exception("Esta entidad es nula");

            _superSampleGameContext.Set<TEntity>().Remove(entity);

            await _superSampleGameContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _superSampleGameContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _superSampleGameContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            _superSampleGameContext.Set<TEntity>().Add(entity);

            await _superSampleGameContext.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
           _superSampleGameContext.Entry(entity).State = EntityState.Modified;

            //_superSampleGameContext.Set<TEntity>().AddOrUpdate(entity);

            await _superSampleGameContext.SaveChangesAsync();

            return entity;
        }
    }
    
}
