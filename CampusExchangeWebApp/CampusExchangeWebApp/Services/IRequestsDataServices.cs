using CampusExchangeWebApp.Models;

namespace CampusExchangeWebApp.Services
{
    public interface IRequestsDataServices
    {
        List<RequestModel> GetAllRequests();
        List<RequestModel> GetRequestsByAccountId(int account_id);
        RequestModel GetRequestById(int id);
        int Insert(RequestModel request);
        int Delete(RequestModel request);
    }
}
