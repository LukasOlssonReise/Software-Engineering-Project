using System.ComponentModel;

namespace CampusExchangeWebApp.Models
{
    public class LoanModel
    {
        // Id
        [DisplayName("Id")]
        public int Id { get; set; }

        // Product Id
        [DisplayName("Product Id")]
        public int ProductId { get; set; }

        // Product Name
        [DisplayName("Product Name")]
        public string ProductName { get; set; }

        // Borrower Account Id
        [DisplayName("Borrower Account Id")]
        public int BorrowerAccountId { get; set; }

        // Borrower Account Name
        [DisplayName("Borrower Account Name")]
        public string BorrowerAccountName { get; set; }

        // Lender Account Id
        [DisplayName("Lender Account Id")]
        public int LenderAccountId { get; set; }

        // Lender Account Name
        [DisplayName("Lender Account Name")]
        public string LenderAccountName { get; set; }

        public DateTime? ExpectedReturnDate { get; set; } = DateTime.Now.AddDays(7);
        public DateTime LoanDate { get; set; } = DateTime.Now;
        public List<LoanModel> BorrowedLoans { get; set; }
        public List<LoanModel> LendLoans { get; set; }
    }
}
