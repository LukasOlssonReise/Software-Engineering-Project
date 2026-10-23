using CampusExchangeWebApp.Models;

namespace CampusExchangeWebApp.Services
{
    public interface IRequestsDataServices
    {
        List<RequestModel> GetAllRequests();
        int Insert(RequestModel request);
    }
}
