using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JessicaFacturacion.Models
{
    public class Cita
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        public int PacienteId { get; private set; } 

        public int TipoServicioId { get; private set; } 

        public DateTime FechaCita { get; private set; }

        public int HoraCita { get; private set; }

        public string? Observaciones { get; private set; }

        public int? PagoId { get; private set; }

        public bool IsCancelled { get; private set; } = false;

        [ForeignKey("TipoServicioId")]
        public virtual TipoServicio TipoServicio { get; private set; } 

        [ForeignKey("PagoId")]
        public virtual Pago Pago { get; private set; } 

        [ForeignKey("PacienteId")]
        public virtual Paciente Paciente { get; private set; } 

        public void CancelCita()
        {
            IsCancelled = true;
        }
    }
}
