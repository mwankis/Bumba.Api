using BQMS.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BQMS.Api.Interfaces
{
    public interface ICategoriesService
    {
        Task<List<Category>> Get();
    }
}
