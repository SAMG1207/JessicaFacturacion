using JessicaFacturacion.Models.Usuario;
using System.ComponentModel.DataAnnotations.Schema;

namespace JessicaFacturacion.Models
{
    public class Cliente : UsuarioAbstract
    {
        public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();

        public virtual ICollection<TipoServicio> TipoServicio { get; set; } = new List<TipoServicio>(); // Fixed initialization  

        public int TipoFacturacionId { get; set; }  

        [ForeignKey("TipoFacturacionId")]
        public virtual TipoFacturacion TipoFacturacion { get; set; } 
    }
}
