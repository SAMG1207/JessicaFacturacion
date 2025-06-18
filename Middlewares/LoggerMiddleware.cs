using JessicaFacturacion.Models;
using JessicaFacturacion.Repository.Logger;

namespace JessicaFacturacion.Middlewares
{
    public class LoggerMiddleware(RequestDelegate next, IServiceScopeFactory scopeFactory)
    {
        private readonly RequestDelegate _next = next;
        private readonly IServiceScopeFactory _scopeFactory = scopeFactory;
        public async Task Invoke(HttpContext context)
        {

            var ip = context.Request.Headers.ContainsKey("X-Forwarded-For")
                ? context.Request.Headers["X-Forwarded-For"].ToString().Split(',').FirstOrDefault()
                : context.Connection.RemoteIpAddress?.ToString() ?? "Desconocida";

            var log = new LoggerPersonalizado
            {
                IPAddress = ip,
                DateTime = DateTime.UtcNow,
                URLto = context.Request.Path + context.Request.QueryString,
            };

            try
            {
                await _next(context);
                log.ResponseCode = context.Response.StatusCode;
            }
            catch (Exception ex)
            {
                log.ResponseCode = 500;
                log.ErrorMessage = ex.Message;
                log.ErrorDetail = ex.StackTrace ?? string.Empty;
                throw;
            }
            finally
            {
                using var scope = _scopeFactory.CreateScope();
                var loggerRepository = scope.ServiceProvider.GetRequiredService<ILoggerRepository>();
                await loggerRepository.AddAsync(log);
            }
        }
    }
}
