using JessicaFacturacion.Data;
using JessicaFacturacion.Repository.GenericRepository.Interface;
using Microsoft.EntityFrameworkCore;

namespace JessicaFacturacion.Repository.GenericRepository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.AddAsync(entity);
        }

        public Task DeleteAsync(T entity)
        {
             _context.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity) // NO tiene el token de cancelacion porque quien guardará será unit of work
        {
            _context.Update(entity);
        }

    }
}
