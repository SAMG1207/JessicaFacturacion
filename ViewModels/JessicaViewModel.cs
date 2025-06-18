using System.ComponentModel.DataAnnotations;

namespace JessicaFacturacion.ViewModels
{
    public class JessicaViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
