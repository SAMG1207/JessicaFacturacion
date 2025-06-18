using JessicaFacturacion.DTO.Paciente;
using JessicaFacturacion.Models;
using JessicaFacturacion.Services.ClienteService;
using JessicaFacturacion.Services.PacienteService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JessicaFacturacion.Controllers
{
    public class PacienteController : Controller
    {
        ILogger<PacienteController> _logger;
        IPacienteService _pacienteService;
        IServiceCliente _serviceCliente;

        public PacienteController(ILogger<PacienteController> logger, IPacienteService pacienteService, IServiceCliente serviceCliente)
        {
            _logger = logger;
            _pacienteService = pacienteService;
            _serviceCliente = serviceCliente;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var clientes = await _serviceCliente.GetClientes();
            ViewBag.listaClientes = clientes;
            return View();
        }

        public async Task<IActionResult> MisPacientes()
        {
            var clientes = await _serviceCliente.GetClientes();
            ViewBag.listaClientes = clientes;
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult CreatePaciente(DTOCreatePaciente dTOCreatePaciente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _pacienteService.Create(dTOCreatePaciente);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> GetPacientes([FromBody] BuscarPacienteDTO buscarPacienteDTO)
        {
            if (!string.IsNullOrEmpty(buscarPacienteDTO.DniPaciente))
            {
                var Paciente = await _pacienteService.GetPacienteByDNI(buscarPacienteDTO.DniPaciente);
                if(Paciente == null)
                {
                    return NotFound("No se ha encontrado paciente con este DNI");
                }
                return Ok(Paciente);
            }

            if(buscarPacienteDTO.ClienteId.HasValue)
            {
                var Pacientes = await _pacienteService.GetPacientesByClienteId((int)buscarPacienteDTO.ClienteId);
                return Ok(Pacientes);
            }
            return BadRequest("Debe proporcionar un DNI o un ID de cliente para realizar la búsqueda.");
        }
        /*
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult CreateCita([FromForm] DTOCreateCita createCita)
        {

        }
        */
    }
}
