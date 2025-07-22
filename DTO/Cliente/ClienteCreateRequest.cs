using JessicaFacturacion.DTO.Usuario;

namespace JessicaFacturacion.DTO.Cliente
{
    public class ClienteCreateRequest : UserCreateRequestAbstract
    {
        public int TipoDeFacturacion { get; set; }
    }
}
