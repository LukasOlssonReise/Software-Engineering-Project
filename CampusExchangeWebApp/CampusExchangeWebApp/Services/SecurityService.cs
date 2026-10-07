using CampusExchangeWebApp.Models;

namespace CampusExchangeWebApp.Services
{
    public class SecurityService
    {
        UsersDAO usersDAO = new UsersDAO();
        public SecurityService()
        {
            
        }

        public bool isValid(UserModel user)
        {
            return usersDAO.FindUserByNameAndPassword(user);
        }
    }
}
