using JessicaFacturacion.Utils.Passwords;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JessicaFacturacion.Models
{
    public class Jessica
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; } = 1;

        [EmailAddress]
        public string Email { get; set; }

        [PasswordPropertyText]
        public string Password { get; set; } 


        private Jessica() { }

        public Jessica(string email, string password, PasswordManager passwordManager)
        {
            Id = 1;
            Email = email;
            Password = passwordManager.HashPassword(password);
        }

        public Jessica (string email, string password)
        {
            Email = email;
            Password = password;
        }

 

        
    }
}
