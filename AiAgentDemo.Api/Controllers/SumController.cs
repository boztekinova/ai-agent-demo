using AiAgentDemo.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AiAgentDemo.Api.Controllers
{
    /// <summary>
    /// Handles calculator-style sum operations.
    /// Exposes POST /api/sum to add two required integer inputs and return their total.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class SumController : ControllerBase
    {
        /// <summary>
        /// Adds NumberOne and NumberTwo from the request body and returns the sum.
        /// Invalid or missing values are rejected by model validation before this action runs.
        /// </summary>
        [HttpPost]
        public ActionResult<SumResponse> Post([FromBody] SumRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);

            // Both values are validated as required integers by SumRequest annotations.
            var sum = request.NumberOne!.Value + request.NumberTwo!.Value;

            return Ok(new SumResponse
            {
                Sum = sum
            });
        }
    }
}
