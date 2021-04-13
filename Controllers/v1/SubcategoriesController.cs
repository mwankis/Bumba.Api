using BQMS.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace BQMS.Api.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SubcategoriesController : Controller
    {
        private readonly ISubcategoriesService _subcategoriesService;

        public SubcategoriesController(ISubcategoriesService subcategoriesService)
        {
            _subcategoriesService = subcategoriesService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([Required]Guid categoryId)
        {
            Guid outGuid;
            if (!Guid.TryParse(categoryId.ToString(),out outGuid))
            {
                return BadRequest();
            }
            var subcategories = await _subcategoriesService.Get(categoryId);
            return Ok(subcategories);
        }
    }
}
