using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JessicaFacturacion.Models.Usuario
{
    public abstract class UsuarioAbstract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get;  set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Telefono { get; set; }

        [Required]
        [MinLength(8)]
        public string DNI { get; set; }

        [Required]
        public string Direccion { get; set; }

        public bool Activo { get; set; } = true;
        public DateTime FechaCreacion { get; set; }
    }
}
