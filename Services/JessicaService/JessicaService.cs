using JessicaFacturacion.Models;
using JessicaFacturacion.UnitOfWork;

namespace JessicaFacturacion.Services.JessicaService
{
    public class JessicaService(IUnitOfWork unitOfWork) : IJessicaService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public Task<bool> ExecuteLogin(string email, string password)
        {
            Jessica jessica = new(email, password);
            return _unitOfWork.JessicaRepository.Login(jessica);
        }
    }
}
