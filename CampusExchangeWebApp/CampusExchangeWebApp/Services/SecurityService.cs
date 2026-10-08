using CampusExchangeWebApp.Models;

namespace CampusExchangeWebApp.Services
{
    public class SecurityService
    {
        AccountsDAO usersDAO = new AccountsDAO();
        public SecurityService()
        {
            
        }

        public bool isValid(AccountModel user)
        {
            return usersDAO.FindUserByNameAndPassword(user);
        }
    }
}
