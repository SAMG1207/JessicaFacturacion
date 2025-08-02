using AutoMapper;
using JessicaFacturacion.DTO.Cita;
using JessicaFacturacion.Models;
using JessicaFacturacion.Services.ClienteService;
using JessicaFacturacion.UnitOfWork;

namespace JessicaFacturacion.Services.CitasService
{
    public class CitaService : ICitaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CitaService> _logger;
        public CitaService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CitaService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public Task<Cita> AddCita(CreateCitaRequest createCitaRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<Cita> AddCitaByPacienteId(CreateCitaRequest createCitaRequest)
        {
            Cita cita = _mapper.Map<Cita>(createCitaRequest);
            await _unitOfWork.CitaRepository.AddAsync(cita);
            return cita;
        }

        public async Task CancelCita(int citaId)
        {
            await _unitOfWork.CitaRepository.AnulaCita(citaId);
            await _unitOfWork.CompleteAsync();
        }

        public Task<IEnumerable<Cita>> GetCitasByClienteId(int clienteId)
        {
            return _unitOfWork.CitaRepository.GetCitasByClienteId(clienteId);
        }

        public Task<IEnumerable<Cita>> GetCitasByMonth(int month, int year)
        {
            return _unitOfWork.CitaRepository.GetCitasByMonthAndYear(month, year);
        }

        public Task<IEnumerable<Cita>> GetCitasByPacientesId(int pacienteId)
        {
            return _unitOfWork.CitaRepository.GetCitasByPacienteId(pacienteId);
        }
    }
}
