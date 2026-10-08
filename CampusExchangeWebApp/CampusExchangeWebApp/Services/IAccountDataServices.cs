using CampusExchangeWebApp.Models;

namespace CampusExchangeWebApp.Services
{
    public interface IAccountDataServices
    {
        List<AccountModel> GetAllAccounts();
        AccountModel GetAccountById(int id);
        int Insert(AccountModel account);
        int Delete(AccountModel account);
        int Update(AccountModel account);
    }
}
