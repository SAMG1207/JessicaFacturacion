using JessicaFacturacion.Models;

namespace JessicaFacturacion.Repository.Jessica
{
    public interface IJessicaRepository
    {
        Task<bool>Login(Models.Jessica jessica);
    }
}
