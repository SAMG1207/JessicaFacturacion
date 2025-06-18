namespace JessicaFacturacion.Services.JessicaService
{
    public interface IJessicaService
    {
        Task<bool> ExecuteLogin(string email, string password);
    }
}
