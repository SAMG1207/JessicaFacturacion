namespace JessicaFacturacion.Repository.GenericRepository.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(); //OBTENER TODOS 
        Task<T> GetByIdAsync(int id); //OBTENER POR ID

        Task AddAsync(T entity); //AGREGAR

        Task UpdateAsync(T entity); //ACTUALIZAR

        Task DeleteAsync(T entity); //ELIMINAR
    }
}
