namespace JessicaFacturacion.Exceptions.Cliente
{
    public class ClienteNoEncontradoException : Exception
    {
        public ClienteNoEncontradoException(int id) : base($"Cliente no encontrado con id: {id}") { } 
    }
    public class ClienteEmailDuplicadoException : Exception
    {
        public ClienteEmailDuplicadoException(string email) : base($"ya existe un cliente con este email{email}") { }
    }
}
