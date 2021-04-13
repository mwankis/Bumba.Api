using BQMS.Api.Interfaces;
using BQMS.Api.Models;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BQMS.Api.Implementations
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IOrganizationService _organizationService;

        public CategoriesService(IDynamics365Service dynamics365Service)
        {
            _organizationService = dynamics365Service.GetOrgService();
        }
      
        public Task<List<Category>> Get()
        {
            var query = new QueryExpression()
            {
                EntityName = "bumba_casecategory",
                ColumnSet = new ColumnSet(true)
            };

            var categories = new List<Category>();

            var entityCollection = _organizationService.RetrieveMultiple(query);

            foreach (var entity in entityCollection.Entities)
            {
                categories.Add(new Category
                {
                    Name = entity.GetAttributeValue<string>("bumba_name"),
                    Id = entity.Id
                });
            }

            return Task.FromResult(categories);
        }
    }
}
