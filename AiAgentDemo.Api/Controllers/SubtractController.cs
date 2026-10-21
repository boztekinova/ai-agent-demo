using AiAgentDemo.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AiAgentDemo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubtractController : ControllerBase
    {
        [HttpPost]
        public ActionResult<SubtractResponse> Post([FromBody] SubtractRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);

            var result = request.NumberOne!.Value - request.NumberTwo!.Value;

            return Ok(new SubtractResponse
            {
                Result = result
            });
        }
    }
}
