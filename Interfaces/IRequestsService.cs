using BQMS.Api.Models;
using System.Threading.Tasks;

namespace BQMS.Api.Interfaces
{
    public interface IRequestsService
    {
        Task<string> CreateRequest(Request request);
        Task<Request> GetRequest(string referenceNumber);
    }
}
