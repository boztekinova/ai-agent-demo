using System.ComponentModel.DataAnnotations;

namespace AiAgentDemo.Api.Models
{
    public class SumRequest
    {
        [Required]
        public int? NumberOne { get; set; }

        [Required]
        public int? NumberTwo { get; set; }
    }
}
