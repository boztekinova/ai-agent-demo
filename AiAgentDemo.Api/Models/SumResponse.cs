namespace AiAgentDemo.Api.Models
{
    /// <summary>
    /// Response body returned by the sum endpoint after a successful calculation.
    /// </summary>
    public class SumResponse
    {
        /// <summary>
        /// The sum of NumberOne and NumberTwo from the request.
        /// </summary>
        public int Sum { get; set; }
    }
}
