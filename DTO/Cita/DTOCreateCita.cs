namespace JessicaFacturacion.DTO.Cita
{
    public class DTOCreateCita
    {
        public int PacienteId;
        public int TipoServicioId;
        public DateTime FechaCita;
        public int HoraCita;
        public string? Observaciones;
        public int? PagoId;
    }
}
