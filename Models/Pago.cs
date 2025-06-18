using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JessicaFacturacion.Models
{
    public class Pago
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        public int TipoServicioId { get; private set; } // 👈 Clave foránea a Servicio

        [Required]
        public DateTime FechaPago { get; private set; }

        [ForeignKey("TipoServicioId")]
        public virtual TipoServicio TipoServicio { get; private set; } // 👈 Propiedad de navegación

    }
}
