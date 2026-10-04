using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CampusExchangeWebApp.Models
{
    public class ProductModel
    {
        // Id
        [DisplayName("Product Id")]
        public int Id { get; set; }

        // Name
        [DisplayName("Product Name")]
        public string Name { get; set; }

        // Description
        [DisplayName("Description")]
        public string Description { get; set; }
    }
}
