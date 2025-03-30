using Microsoft.EntityFrameworkCore;

namespace TrafficBackendAPI.UserModule.Repositories
{
    internal class GenericRepository<T, TContext> : IGenericRepository<T, TContext> 
        where T : class
        where TContext : DbContext
    {
        #region Variables
        private readonly TContext _dbContext;
        #endregion

        #region Constructor
        public GenericRepository(TContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region Methods
        public async Task<T> Add(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task Delete(Guid id)
        {
            var entity = await GetById(id);

            if (entity is not null)
            {
                _dbContext.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<T>?> GetAll(List<Guid>? templateListId, bool asNoTracking)
        {
            var result = new List<T>();

            if(templateListId is null && !asNoTracking)
            {
                result = await _dbContext.Set<T>().ToListAsync();
            }
            else if(templateListId is null && asNoTracking)
            {
                result = await _dbContext.Set<T>().AsNoTracking().ToListAsync();
            }
            else if (templateListId is not null && !asNoTracking)
            {
                result = await _dbContext.Set<T>()
                    .Where(x => templateListId.Contains(EF.Property<Guid>(x, "Id")))
                    .ToListAsync();
            }
            else if(templateListId is not null && asNoTracking)
            {
                result = await _dbContext.Set<T>()
                    .Where(x => templateListId.Contains(EF.Property<Guid>(x, "Id")))
                    .AsNoTracking()
                    .ToListAsync();
            }

            return result;
        }

        public async Task<T?> GetById(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task Update(T entity)
        {
            _dbContext.Set<T>().Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}
