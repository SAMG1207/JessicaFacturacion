using AutoMapper;
using JessicaFacturacion.DTO.Cita;
using JessicaFacturacion.Models;

namespace JessicaFacturacion.Mappers
{
    public class CitaProfile : Profile
    {
        public CitaProfile() {

            CreateMap<DTOCreateCita, Cita>();
        }
    }
}
