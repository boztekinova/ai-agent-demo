using System.ComponentModel.DataAnnotations;

namespace AiAgentDemo.Api.Models
{
    public class SubtractRequest
    {
        [Required]
        public double? NumberOne { get; set; }

        [Required]
        public double? NumberTwo { get; set; }
    }
}
