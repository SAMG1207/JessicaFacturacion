namespace JessicaFacturacion.Repository.UsuarioRepository
{
    public interface IUsuarioRepository<T> where T : class
    {
        Task<T> GetByDni(string dni);
        Task<T> GetByEmail(string email);
    }
}
