using JessicaFacturacion.Models;
using JessicaFacturacion.Repository.Jessica;

namespace JessicaFacturacion.Services.JessicaService
{
    public class JessicaService(IJessicaRepository jessicaRepository) : IJessicaService
    {
        private readonly IJessicaRepository _jessicaRepository = jessicaRepository;

        public Task<bool> ExecuteLogin(string email, string password)
        {
            Jessica jessica = new(email, password);
            return  _jessicaRepository.Login(jessica);
        }
    }
}
