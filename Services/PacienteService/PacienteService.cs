using AutoMapper;
using JessicaFacturacion.DTO.Paciente;
using JessicaFacturacion.Models;
using JessicaFacturacion.UnitOfWork;

namespace JessicaFacturacion.Services.PacienteService
{
    public class PacienteService : IPacienteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PacienteService(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Create(DTOCreatePaciente dTOCreatePaciente)
        {
            Paciente paciente = _mapper.Map<Paciente>(dTOCreatePaciente);
            await _unitOfWork.PacienteRepository.AddAsync(paciente);
        }

        public async Task<Paciente?> GetPacienteByDNI(string? dNI)
        {
            return await _unitOfWork.PacienteRepository.GetPacienteByDNI(dNI);
        }

        public Task<IEnumerable<Paciente>> GetPacientesByClienteId(int clienteId)
        {
            return _unitOfWork.PacienteRepository.GetPacientesByCliente(clienteId);
        }
    }
}
