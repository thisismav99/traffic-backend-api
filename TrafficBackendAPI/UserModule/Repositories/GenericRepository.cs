using Microsoft.EntityFrameworkCore;

namespace TrafficBackendAPI.UserModule.Repositories
{
    internal class GenericRepository<T, TContext> : IGenericRepository<T, TContext>
        where T : class
        where TContext : DbContext
    {
        #region Variables
        private readonly TContext _context;
        #endregion

        #region Constructor
        public GenericRepository(TContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        public async Task<T> Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>?> GetAll(bool asNoTracking)
        {
            if (asNoTracking)
            {
                return await _context.Set<T>().AsNoTracking().ToListAsync();
            }
            else
            {
                return await _context.Set<T>().ToListAsync();
            }
        }

        public async Task<List<T>?> GetAllById(List<Guid> templateListId, bool asNoTracking)
        {
            if (asNoTracking)
            {
                return await _context
                    .Set<T>()
                    .Where(x => templateListId.Contains(EF.Property<Guid>(x, "Id")))
                    .AsNoTracking()
                    .ToListAsync();
            }
            else
            {
                return await _context
                    .Set<T>()
                    .Where(x => templateListId.Contains(EF.Property<Guid>(x, "Id")))
                    .ToListAsync();
            }
        }

        public async Task<T?> GetById(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task Update(T entity)
        {
            _context.Set<T>().Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        #endregion
    }
}
