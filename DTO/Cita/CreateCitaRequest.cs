namespace JessicaFacturacion.DTO.Cita
{
    public record CreateCitaRequest
    {
        public int PacienteId { get; init; }
        public int TipoServicioId { get; init; }
        public DateTime FechaCita { get; init; }
        public int HoraCita { get; init; }
        public bool IsCancelled { get; init; } = false;
        public string? Observaciones { get; init; }
        public int? PagoId { get; init; }
    }
}
