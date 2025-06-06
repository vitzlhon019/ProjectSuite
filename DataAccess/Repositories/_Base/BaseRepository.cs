using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories._Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        private readonly DbSet<TEntity> _entity;
        public BaseRepository(DbContext context)
        {
            _entity = context.Set<TEntity>();
        }

        //Get
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
            => await _entity.ToListAsync();

        public async Task<TEntity?> GetByIdAsync(int id)
            => await _entity.FindAsync(id);
        //Add
        public async Task AddAsync(TEntity entity)
        {
            await _entity.AddAsync(entity);
        }
        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _entity.AddRangeAsync(entities);
        }
        //Remove
        public void Remove(TEntity entity)
        {
            _entity.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _entity.RemoveRange(entities);
        }

    }
}
