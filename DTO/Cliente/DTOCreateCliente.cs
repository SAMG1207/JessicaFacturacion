using JessicaFacturacion.DTO.Usuario;

namespace JessicaFacturacion.DTO.Cliente
{
    public class DTOCreateCliente : DTOCrearUsuarioAbstract
    {
        public int TipoDeFacturacion { get; set; }
    }
}
