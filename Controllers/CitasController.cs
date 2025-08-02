using JessicaFacturacion.DTO.Cita;
using JessicaFacturacion.Services.CitasService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JessicaFacturacion.Controllers
{
    public class CitasController : Controller
    {
        private readonly ILogger<CitasController> _logger;
        private readonly CancellationToken cancellationToken;
        private readonly ICitaService citaService;
        public CitasController(ILogger<CitasController> logger, CancellationToken cancellationToken, ICitaService citaService)
        {
            _logger = logger;
            this.cancellationToken = cancellationToken;
            this.citaService = citaService;
        }

        [HttpGet]
        public IActionResult Citas()
        {
            return View();
        }

        [HttpGet("CitasPorMesAnio/{mes}/mes/{anio}/anio")]
        public async Task<IActionResult> CitasPorMesAnio(int mes, int anio)
        {
            var citas = await citaService.GetCitasByMonth(mes, anio);
            ViewBag.listaCitasPorMesAnio  = citas;
            return View();
        }

        [HttpGet("VerCitasPorPacientes/{pacienteId}/PacienteId")]
        public async Task<IActionResult> VerCitasPorPaciente(int pacienteId)
        {
            var citas = await citaService.GetCitasByPacientesId(pacienteId);
            ViewBag.listaCitasPorPaciente = citas;
            return View();
        }

        [HttpGet("VerCitasPorClientes/{clienteId}/ClienteId")]
        public async Task<IActionResult> VerCitasPorCliente(int clienteId)
        {
            var citas = await citaService.GetCitasByClienteId(clienteId);
            ViewBag.listaCitasPorCliente = citas;
            return View();
        }

        [HttpPost("CreateCita")]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> CreateCita([FromForm]CreateCitaRequest createCitaRequest)
        {
            if (createCitaRequest == null)
                return BadRequest("Datos de la cita no proporcionados.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var cita = await citaService.AddCita(createCitaRequest);
            if(cita == null)
            {
                return StatusCode(500, "No se pudo crear la cita. Intente nuevamente.");
            }
            return Ok();
        }
    }

}
