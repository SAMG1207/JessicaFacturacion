namespace JessicaFacturacion.DTO.Cita
{
    public struct DTOCreateCita
    {
        public int PacienteId;
        public int TipoServicioId;
        public DateTime FechaCita;
        public int HoraCita;
        public string? Observaciones;
        public int? PagoId;
    }

}
