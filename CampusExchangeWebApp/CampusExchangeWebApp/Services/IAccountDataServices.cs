using CampusExchangeWebApp.Models;

namespace CampusExchangeWebApp.Services
{
    public interface IAccountDataServices
    {
        AccountModel GetAccountById(int id);
    }
}
