using Microsoft.Xrm.Sdk;
using System.Threading.Tasks;

namespace BQMS.Api.Interfaces
{
    public interface IDynamics365Service
    {
        IOrganizationService GetOrgService();
    }
}
