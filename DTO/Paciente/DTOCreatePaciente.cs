using JessicaFacturacion.DTO.Usuario;

namespace JessicaFacturacion.DTO.Paciente
{
    public class DTOCreatePaciente : DTOCrearUsuarioAbstract
    {
        public int ClienteId { get; set; }
    }
}
