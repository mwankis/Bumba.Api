using BQMS.Api.Models;
using Microsoft.Xrm.Sdk;
using System.Threading.Tasks;

namespace BQMS.Api.Interfaces
{
    public interface IContactsService
    {
        Task<EntityReference> GetCustomer(Request request);
    }
}
