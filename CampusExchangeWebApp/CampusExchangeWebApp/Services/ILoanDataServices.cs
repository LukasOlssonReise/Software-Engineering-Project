using CampusExchangeWebApp.Models;

namespace CampusExchangeWebApp.Services
{
    public interface ILoanDataServices
    {
        List<LoanModel> GetLoansByAccountId(int account_id);
        LoanModel GetLoanById(int id);
        List<LoanModel> GetLoansByBorrowerAccountId(int account_id);
        List<LoanModel> GetLoansByLenderAccountId(int account_id);
        int Insert(LoanModel loan);
        int Delete(LoanModel loan);
    }
}
