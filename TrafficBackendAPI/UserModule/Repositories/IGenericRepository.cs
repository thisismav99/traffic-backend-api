using Microsoft.EntityFrameworkCore;

namespace TrafficBackendAPI.UserModule.Repositories
{
    internal interface IGenericRepository<T, TContext> 
        where T : class
        where TContext : DbContext
    {
        Task<T> Add(T entity);
        Task<T?> GetById(Guid id);
        Task<List<T>?> GetAll();
        Task Update(T entity);
        Task Delete(Guid id);
    }
}
