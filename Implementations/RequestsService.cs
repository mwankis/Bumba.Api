using BQMS.Api.Interfaces;
using BQMS.Api.Models;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Threading.Tasks;

namespace BQMS.Api.Implementations
{
    public class RequestsService : IRequestsService
    {
        private readonly IOrganizationService _organizationService;
        private readonly IContactsService _contactsService;

        public RequestsService(IDynamics365Service dynamics365Service, IContactsService contactsService)
        {
            _organizationService = dynamics365Service.GetOrgService();
            _contactsService = contactsService;
        }
        public async Task<string> CreateRequest(Request request)
        {
            var customer = await _contactsService.GetCustomer(request);
            var newcase = new Entity("incident");
            newcase["title"] = request.Title;
            newcase["caseorigincode"] = new OptionSetValue(3);
            newcase["bumba_casecategoryid"] = new EntityReference("bumba_casecategory", request.CategoryId);
            newcase["bumba_casesubcategoryid"] = new EntityReference("bumba_casesubcategory", request.SubcategoryId);
            newcase["customerid"] = customer;
            newcase["description"] = request.Description;
            newcase["statuscode"] = new OptionSetValue(865650000);
            var caseId = _organizationService.Create(newcase);

            var createdCase = _organizationService.Retrieve("incident", caseId, new ColumnSet("ticketnumber"));

            var refNumber = createdCase.GetAttributeValue<string>("ticketnumber");
            return refNumber;
        }

        public Task<Request> GetRequest(string referenceNumber)
        {
            var query = new QueryExpression()
            {
                EntityName = "incident",
                ColumnSet = new ColumnSet(true)
            };
            var filter1 = new FilterExpression();
            filter1.AddCondition(new ConditionExpression("ticketnumber", ConditionOperator.Equal, referenceNumber));
            query.Criteria.AddFilter(filter1);
            Request request = null;

            var entityCollection = _organizationService.RetrieveMultiple(query);
            if (entityCollection.Entities.Count == 1)
            {
                var entity = entityCollection.Entities[0];
               request = new Request
               {
                   ReferenceNumber = referenceNumber,
                   Description = entity.GetAttributeValue<string>("description")
               };
            }   
            
            return Task.FromResult(request);
        }
    }
}
