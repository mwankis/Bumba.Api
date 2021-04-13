using BQMS.Api.Interfaces;
using BQMS.Api.Models;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System.Threading.Tasks;

namespace BQMS.Api.Implementations
{
    public class ContactsService : IContactsService
    {
        private readonly IOrganizationService _organizationService;

        public ContactsService(IDynamics365Service dynamics365Service)
        {
            _organizationService =  dynamics365Service.GetOrgService();
        }
        public Task<EntityReference> GetCustomer(Request request)
        {
            var query = new QueryExpression()
            {
                EntityName = "contact",
                ColumnSet = new ColumnSet(true),
            };

            var filter1 = new FilterExpression();
            filter1.AddCondition(new ConditionExpression("emailaddress1", ConditionOperator.Equal, request.Email.Trim()));
            query.Criteria.AddFilter(filter1);

            var entityCollection = _organizationService.RetrieveMultiple(query);

            if (entityCollection.Entities.Count == 0)
            {
                var newContact = new Entity("contact");
                newContact["firstname"] = request.FirstName;
                newContact["lastname"] = request.LastName;
                newContact["emailaddress1"] = request.Email;

                var contactId = _organizationService.Create(newContact);
                var contactRef =  new EntityReference("contact", contactId);
                return Task.FromResult(contactRef);
            }

            var existingContactRef = new EntityReference("contact", entityCollection.Entities[0].Id);
            return Task.FromResult(existingContactRef);
        }
    }
}
