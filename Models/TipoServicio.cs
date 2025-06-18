using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JessicaFacturacion.Models
{
    public class TipoServicio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        [Required]
        public string Descripcion { get; private set; }

        [Required]
        public int NumeroConsultas { get; private set; }

        [Required]
        public double Precio { get; private set; }

        [Required]
        public int ClienteId { get; private set; } // 👈 Clave foránea a Cliente

        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; private set; } // 👈 Clave foránea a Cliente
    }
}
