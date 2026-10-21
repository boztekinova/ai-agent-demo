using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AiAgentDemo.Api.Models
{
    public class SubtractRequest
    {
        [JsonRequired]
        [Required]
        public double NumberOne { get; set; }

        [JsonRequired]
        [Required]
        public double NumberTwo { get; set; }
    }
}
