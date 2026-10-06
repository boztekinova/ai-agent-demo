using AiAgentDemo.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AiAgentDemo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SumController : ControllerBase
    {
        [HttpPost]
        public ActionResult<SumResponse> Post([FromBody] SumRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);

            var sum = request.NumberOne!.Value + request.NumberTwo!.Value;

            return Ok(new SumResponse
            {
                Sum = sum
            });
        }
    }
}
