using AiAgentDemo.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AiAgentDemo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubtractController : ControllerBase
    {
        /// <summary>
        /// Accepts two required double values in the request body and returns their difference
        /// (NumberOne minus NumberTwo) as JSON. Model validation rejects missing, null, or
        /// non-numeric inputs before this action runs.
        /// </summary>
        /// <param name="request">The subtraction operands from the request body.</param>
        /// <returns>200 OK with the computed difference, or 400 Bad Request when validation fails.</returns>
        [HttpPost]
        public ActionResult<SubtractResponse> Post([FromBody] SubtractRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);

            var result = request.NumberOne - request.NumberTwo;

            return Ok(new SubtractResponse
            {
                Result = result
            });
        }
    }
}
