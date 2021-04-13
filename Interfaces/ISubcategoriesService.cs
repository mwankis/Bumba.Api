using BQMS.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BQMS.Api.Interfaces
{
    public interface ISubcategoriesService
    {
        Task<List<Subcategory>> Get(Guid categoryId);
    }
}
