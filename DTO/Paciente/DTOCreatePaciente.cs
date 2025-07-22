using JessicaFacturacion.DTO.Usuario;

namespace JessicaFacturacion.DTO.Paciente
{
    public class DTOCreatePaciente : UserCreateRequestAbstract
    {
        public int ClienteId { get; set; }
    }
}
