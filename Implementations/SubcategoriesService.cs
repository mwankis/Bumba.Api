using BQMS.Api.Interfaces;
using BQMS.Api.Models;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BQMS.Api.Implementations
{
    public class SubcategoriesService : ISubcategoriesService
    {
        private readonly IOrganizationService _organizationService;

        public SubcategoriesService(IDynamics365Service dynamics365Service)
        {
            _organizationService = dynamics365Service.GetOrgService();
        }
        public Task<List<Subcategory>> Get(Guid categoryId)
        {
            var query = new QueryExpression()
            {
                EntityName = "bumba_casesubcategory",
                ColumnSet = new ColumnSet(true)
            };
            var filter1 = new FilterExpression();
            filter1.AddCondition(new ConditionExpression("bumba_casecategoryid", ConditionOperator.Equal, categoryId));
            query.Criteria.AddFilter(filter1);


            var entityCollection = _organizationService.RetrieveMultiple(query);

            var subcategories = new List<Subcategory> { };

            foreach (var entity in entityCollection.Entities)
            {
                subcategories.Add(new Subcategory
                {
                    Name = entity.GetAttributeValue<string>("bumba_name"),
                    Id = entity.Id.ToString()
                });
            }

            return Task.FromResult(subcategories);
        }
    }
}
