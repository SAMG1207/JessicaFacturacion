namespace JessicaFacturacion.DTO.Usuario
{
    public abstract class UserUpdateRequestAbstract : UserCreateRequestAbstract
    {
        public int Id { get; set; }
    }
}
