using System.ComponentModel;

namespace CampusExchangeWebApp.Models
{
    public class RequestModel
    {
        // Id
        [DisplayName("Id")]
        public int Id { get; set; }

        // Product Name
        [DisplayName("Product Name")]
        public string ProductName { get; set; }

        // Product Id
        [DisplayName("Product Id")]
        public int ProductId { get; set; }

        // Account Name
        [DisplayName("Account Name")]
        public string AccountName { get; set; }

        // Account Id
        [DisplayName("Account Id")]
        public int AccountId { get; set; }

        public List<RequestModel> SentRequests { get; set; }
        public List<RequestModel> IncomingRequests { get; set; }
    }
}
