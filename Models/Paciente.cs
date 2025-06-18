using JessicaFacturacion.Models.Usuario;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JessicaFacturacion.Models
{
    public class Paciente : UsuarioAbstract
    {
        [Required]
        public int ClienteId { get; private set; }

        public ICollection<Cita> Cita { get; private set; } = new List<Cita>();

        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; }
    }
}
