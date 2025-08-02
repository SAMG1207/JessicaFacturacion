using JessicaFacturacion.Services.ClienteService;
using JessicaFacturacion.Services.TiposDeFacturacionService;
using Microsoft.AspNetCore.Mvc;

namespace JessicaFacturacion.Controllers
{
    public class CitasController(
        ILogger<ClientesController> logger
        ) : Controller
    {
        private readonly ILogger<ClientesController> _logger = logger;
        private CancellationToken cancellationToken;
    }

    [HttpGet]
}
