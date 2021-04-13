using BQMS.Api.Interfaces;
using BQMS.Api.Models;
using Microsoft.Extensions.Options;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;

namespace BQMS.Api.Implementations
{
    public class Dynamics365Service : IDynamics365Service
    {
        private readonly DynamicsSettings _dynamicsSettings;

        public Dynamics365Service(IOptions<DynamicsSettings> dynamicsSettings)
        {
            _dynamicsSettings = dynamicsSettings.Value;
        }
        public IOrganizationService GetOrgService()
        {
            var conn = new CrmServiceClient($@"AuthType=ClientSecret;
            url={_dynamicsSettings.OrganisationUrl};
            ClientId={_dynamicsSettings.ClientId};
            ClientSecret={_dynamicsSettings.ClientSecret}");
            var organizationService = conn.OrganizationWebProxyClient != null ? conn.OrganizationWebProxyClient : (IOrganizationService)conn.OrganizationServiceProxy;

            return organizationService;
        }
    }
}
