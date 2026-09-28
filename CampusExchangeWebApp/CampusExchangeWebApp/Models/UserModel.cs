using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CampusExchangeWebApp.Models
{
    public class UserModel
    {
        // Id
        [DisplayName("Account Id")]
        public int Id { get; set; }

        // Name
        [DisplayName("Name")]
        [Required]
        public string Name { get; set; }

        // Password
        [DisplayName("Password")]
        [Required]
        public string Password { get; set; }

        // Email
        [DisplayName("Email")]
        [Required]
        public string Email { get; set; }
    }
}
