using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CampusExchangeWebApp.Models
{
    public class ProductModel
    {
        // Id
        [DisplayName("Id")]
        public int Id { get; set; }

        // Name
        [DisplayName("Name")]
        [Required]
        public string Name { get; set; }

        // Description
        [DisplayName("Description")]
        [Required]
        public string Description { get; set; }

        // Category
        [DisplayName("Category")]
        [Required]
        public string Category { get; set; }

        // Photo
        [DisplayName("Photo")]
        public string Photo { get; set; }

        // Account Id
        [DisplayName("Account Id")]
        public int AccountId { get; set; }

        // Account Name
        [DisplayName("Account Name")]
        public string AccountUserName { get; set; }
    }
}
