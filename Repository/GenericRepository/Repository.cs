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

        public async Task<bool> AddAsync(T entity)
        {
            try
            {
                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();
                return true;
            }catch(Exception e)
            {
                Console.WriteLine($"Error al agregar entidad: {e.Message}");
                Console.WriteLine(e.StackTrace);
                return false;
            }

        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var entity = await _context.Set<T>().FindAsync(id);
                if (entity == null)
                {
                    return false;
                }
                _context.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }catch(Exception e)
            {
                Console.WriteLine($"Error al eliminar entidad: {e.Message}");
                return false;
            }

        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _context.Set<T>().ToListAsync();
            }
            catch(Exception e)
            {
                Console.WriteLine("No se han encontrado objetos");
                return [];
            }
            
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id) ??
                throw new Exception("No existe este elemento");
        }

        public async Task<T?> UpdateAsync(T entity)
        {
            try
            {
                _context.Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch(Exception e)
            {
                Console.WriteLine("Error al actualizar la entidad: " + e.Message);
                return null;
            }

        }
    }
}
