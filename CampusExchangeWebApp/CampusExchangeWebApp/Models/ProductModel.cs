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
        public string Name { get; set; }

        // Description
        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Photo")]
        public string Photo {  get; set; }
    }
}
