using JessicaFacturacion.Models;
using JessicaFacturacion.Repository.Jessica;

namespace JessicaFacturacion.Services.JessicaService
{
    public class JessicaService(IJessicaRepository jessicaRepository) : IJessicaService
    {
        private readonly IJessicaRepository _jessicaRepository = jessicaRepository;

        public async Task<bool> ExecuteLogin(string email, string password)
        {
            Jessica jessica = new(email, password);
            return await _jessicaRepository.Login(jessica);
        }
    }
}
