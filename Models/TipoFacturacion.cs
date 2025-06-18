using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JessicaFacturacion.Models
{
    public class TipoFacturacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Tipo { get; set; }
        public ICollection<Cliente> Clientes { get; set; } = [];

        public TipoFacturacion() { }

        public TipoFacturacion(string tipo)
        {
            if (string.IsNullOrWhiteSpace(tipo))
            {
                throw new ArgumentException("El tipo es nulo en el constructor");
            }

            SetTipo(tipo);
        }

        public void SetTipo (string tipo)
        {
            Tipo = tipo;
        }

    }
}
