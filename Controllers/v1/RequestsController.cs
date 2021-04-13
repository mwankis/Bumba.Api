using BQMS.Api.Interfaces;
using BQMS.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace BQMS.Api.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RequestsController : Controller
    {
        private readonly IRequestsService _requestsService;

        public RequestsController(IRequestsService requestsService)
        {
            _requestsService = requestsService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Request request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var createdRequest = await _requestsService.CreateRequest(request);
            return Ok(createdRequest);
        }

        [HttpGet]
        public async Task<IActionResult> Get([Required]string refNumber)
        {
            if (refNumber is null)
            {
                return BadRequest();
            }
           
            var request = await _requestsService.GetRequest(refNumber);
            return Ok(request);
        }
    }
}
