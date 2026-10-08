using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CampusExchangeWebApp.Models
{
    public class AccountModel
    {
        // Id
        [DisplayName("Id")]
        public int Id { get; set; }

        // Name
        [DisplayName("Name")]
        [Required]
        public string UserName { get; set; }

        // Password
        [DisplayName("Password")]
        [Required]
        public string Password { get; set; }

        // Email
        [DisplayName("Email")]
        [Required]
        public string Email { get; set; }

        public string toString()
        {
            return "(Name, Password) => " + UserName + ", " + Password;
        }
    }
}
