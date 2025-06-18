using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JessicaFacturacion.Models
{
    public class LoggerPersonalizado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(45)]
        public string IPAddress { get; set; }

        public DateTime DateTime { get; set; } = DateTime.Now;

        [MaxLength(2048)]
        public string URLto { get; set; }

        public int ResponseCode { get; set; }

        public string ErrorMessage { get; set; } = string.Empty;

        public string ErrorDetail { get; set; } = string.Empty ;

    }
}
