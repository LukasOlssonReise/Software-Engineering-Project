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
        public string? Photo { get; set; }

        // Owner Id
        [DisplayName("Owner Id")]
        public int OwnerId { get; set; }

        // Owner Name
        [DisplayName("Owner Name")]
        public string OwnerName { get; set; }
    }
}
