using AutoMapper;
using JessicaFacturacion.DTO.Paciente;
using JessicaFacturacion.Models;

namespace JessicaFacturacion.Mappers
{
    public class PacienteProfile : Profile
    {
        public PacienteProfile() 
        {
            
            CreateMap<DTOCreatePaciente, Paciente>()
                .ForMember(dest => dest.FechaCreacion, opt => opt.MapFrom(_ => DateTime.UtcNow));

        }
    }
}
