namespace JessicaFacturacion.Repository.GenericRepository.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(); //OBTENER TODOS 
        Task<T> GetByIdAsync(int id); //OBTENER POR ID

        Task<bool> AddAsync(T entity); //AGREGAR

        Task<T> UpdateAsync(T entity); //ACTUALIZAR

        Task<bool> DeleteAsync(int id); //ELIMINAR
    }
}
