using JessicaFacturacion.DTO.Cliente;
using JessicaFacturacion.Services.ClienteService;
using JessicaFacturacion.Services.TiposDeFacturacionService;
using Microsoft.AspNetCore.Mvc;

namespace JessicaFacturacion.Controllers
{
    public class ClientesController(
        ILogger<ClientesController> logger, 
        IServiceCliente serviceCliente, 
        ITiposDeFacturacionService tiposDeFacturacionService
        
        ) : Controller
    {
        private readonly ILogger<ClientesController> _logger = logger;
        private readonly IServiceCliente _serviceCliente = serviceCliente;
        private readonly ITiposDeFacturacionService _tiposDeFacturacionService = tiposDeFacturacionService;
        

        [HttpGet]
        public async Task<IActionResult> Clientes()
        {
            var tipos = await _tiposDeFacturacionService.GetTiposFacturacion();
            ViewBag.TiposDeFacturacion = tipos;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> MisClientes()
        {
            var clientes = await _serviceCliente.GetClientes();
            return View(clientes);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> CreateCliente([FromForm] DTOCreateCliente dTOCreateCliente)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _serviceCliente.Create(dTOCreateCliente);
            //return Ok();
            return RedirectToAction("Clientes");
        }
    }
}
