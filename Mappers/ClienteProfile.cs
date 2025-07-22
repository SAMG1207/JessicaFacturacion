using AutoMapper;
using JessicaFacturacion.DTO.Cliente;
using JessicaFacturacion.Models;

namespace JessicaFacturacion.Mappers
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile() {

            CreateMap<ClienteCreateRequest, Cliente>()
                .ForMember(dest => dest.TipoFacturacionId, opt => opt.MapFrom(src => src.TipoDeFacturacion))
                .ForMember(dest => dest.FechaCreacion, opt => opt.MapFrom(_ => DateTime.UtcNow));
            //los formember se usar para mapear elementos con nombres distintos, eso en el caso de 
            //TipodeFacturacion, en el otro caso FechaCreacion no aparece en el DTO entonces simplemente se pone UTCNOW
        }
    }
}
