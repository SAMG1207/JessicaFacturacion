using AutoMapper;
using JessicaFacturacion.DTO.Paciente;
using JessicaFacturacion.Models;
using JessicaFacturacion.Repository.PacienteRepository;

namespace JessicaFacturacion.Services.PacienteService
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IMapper _mapper;
        public PacienteService(IPacienteRepository pacienteRepository, IMapper mapper) 
        {
            _pacienteRepository = pacienteRepository;
            _mapper = mapper;
        }

        public async Task<bool> Create(DTOCreatePaciente dTOCreatePaciente)
        {
            Paciente paciente = _mapper.Map<Paciente>(dTOCreatePaciente);
            var result = await _pacienteRepository.AddAsync(paciente);
            return result;
        }

        public async Task<Paciente?> GetPacienteByDNI(string? dNI)
        {
            if (string.IsNullOrWhiteSpace(dNI))
            {
                return null;
            }

            return await _pacienteRepository.GetPacienteByDNI(dNI);
        }

        public Task<IEnumerable<Paciente>> GetPacientesByClienteId(int clienteId)
        {
            return _pacienteRepository.GetPacientesByCliente(clienteId);
        }
    }
}
